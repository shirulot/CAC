using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

//角色卡
public class Character : Card
{
    //魔术
    public Magic magic;
    // 攻击力最近一次的增量
    public int LastAttackIncrement = 0;

    public Player Player;

    // public GameObject Obj;
    public readonly CharacterInfo Info = new CharacterInfo();

    public virtual void CharacterDeath()
    {
        EffectAttach();
    }


    public override void OnCardDraw()
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnCardDraw(); });
    }

    public override void OnAttackMiss()
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAttackMiss(); });
    }

    public override void OnAvoidAttack()
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAvoidAttack(); });
    }

    public override void OnTurnStart()
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnTurnStart(); });
    }

    public override void OnAttackStart(Card targetCharacter)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAttackStart(targetCharacter); });
    }

    public override void OnBeforeBeingAttacked(Character character)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnBeforeBeingAttacked(character); });
    }

    public override void OnAfterBeingAttacked(Character character)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAfterBeingAttacked(character); });
    }

    public override void OnBeforeCounterattack(Character counterTarget)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnBeforeCounterattack(counterTarget); });
    }

    public override void OnAfterCounterattack(Character counterTarget)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAfterCounterattack(counterTarget); });
    }

    public override void OnAttackEnd(Card targetCharacter)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnAttackEnd(targetCharacter); });
    }

    public override void OnTurnEnd()
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnTurnEnd(); });
    }
    
    public override void OnCardRecycle(List<Card> depositList)
    {
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit lifecycle) { lifecycle.OnTurnEnd(); });
    }

    // Hp变动 增加/减少
    public virtual void ChangeHp(int incremental, bool breakIsLock = false)
    {
        var beforeHp = Info.Hp;
        Info.Hp += incremental;
        if (breakIsLock && Info.Hp < 1) Info.Hp = 1;
        incremental = Info.Hp - beforeHp;
        GetComponent<GameBroadcast>().PostLifecycle(magic,delegate(Unit unit) { unit.OnHpChange(incremental, this); });
    }

    
    //buff 赋予
    public virtual T BuffAttach<T>(int level = 1) where T : Buff
    {
        var holderBuff = GetComponentInChildren<T>();
        T buff;
        if (holderBuff == null)
        {
            buff = gameObject.AddComponent<T>();
            buff.BuffAttach();
        }
        else
        {
            buff = holderBuff;
            holderBuff.BuffUp(level);
        }

        return buff;
    }

    //buff清除
    public virtual void BuffDetach(Type type)
    {
        var buff = GetComponentInChildren(type);
        if (buff == null) return;
        (buff as Buff)?.OnBuffDetach();
        Destroy(buff);
    }

    //伤害计算暂不做过于复杂逻辑 
    public void Damage(int damage,Unit injurer , bool isPiercing = false)
    {
        var breakIsLock = false;
        if (injurer != null)
        {
            foreach (var lockType in Info.BreakLockTypes)
            {
                if (breakIsLock.GetType() == lockType)
                {
                    breakIsLock = true;
                }
            }
        }
        
        OnDamage(damage,injurer, isPiercing,breakIsLock);
        OnAfterDamage(damage,injurer);
    }


    //伤害计算方法
    public virtual void OnDamage(int damage, Unit injurer, bool isPiercing, bool breakIsLock)
    {
        // 是否为穿刺伤害 
        if (isPiercing)
        {
            ChangeHp(-damage,breakIsLock);
        }
        else
        {
            Info.Aegis -= damage;
            // 护盾无法抵消伤害 对溢出伤害进行计算
            if (Info.Aegis >= 0) return;
            ChangeHp(Info.Aegis,breakIsLock);
            Info.Aegis = 0;
        }
    }

    //受到伤害后 时点 确认破坏之前
    public virtual void OnAfterDamage(int damage, Unit injurer)
    {
    }

    public virtual void ChangeAttack(int incremental)
    {
        Info.Attack += incremental;
        LastAttackIncrement = incremental;
    }

    public virtual void AegisChange(int incremental)
    {
        var temp = Info.Aegis + incremental;
        Info.Aegis = temp <= 0 ? 0 : incremental;
    }


    public virtual void OnAfterMove()
    {
    }

    // 当前角色是否能反击 如果能 被反击角色是否在攻击范围之内
    public virtual bool CanCounterAttack() => false;

    // 连击攻击前
    public virtual void OnBeforeComboHit(Character targetCharacter)
    {
        if (!Info.SuperComboHit)
        {
            int lastAttack = Info.Attack;
            var decrement = Mathf.FloorToInt(Info.Attack / 2f);

            LastAttackIncrement = lastAttack - Info.Attack;
            //TODO 攻击力变动事件广播 
        }
    }

    // 连击后
    public virtual void OnAfterComboHit(Character targetCharacter)
    {
    }

    public virtual bool IsPiercing() => false;

    // 角色进场之前 获得能力
    protected virtual void EffectAttach()
    {
    }

    public virtual void AttackTarget(Card target)
    {
        if (target is Character targetCharacter)
        {
            // 伤害结算
            targetCharacter.Damage(Info.Attack,this, IsPiercing());
        }
        else if (target is Golem targetGolem)
        {
            targetGolem.Charge(Info.Attack, this);
        }
    }

    public void MagicAttach(Magic magic)
    {
        this.magic = magic;
    }
}