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

    List<Effect> effectList;

    //单回合攻击力增减等
    protected Dictionary<SingleTurn, int> SingleTurnMemo = new Dictionary<SingleTurn, int>();

    // 攻击力最近一次的增量
    public int LastAttackIncrement = 0;

    public Player Player;
    // public GameObject Obj;
    private CharacterInfo _info = new CharacterInfo();

    public virtual void CharacterDeath(Player player)
    {
        this.Player = player;
        EffectAttach();
    }

    public CharacterInfo Info
    {
        get { return _info; }
    }


    public override void OnCardDraw()
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnCardDraw(); });
    }

    public override void OnAttackMiss()
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAttackMiss(); });
    }

    public override void OnAvoidAttack()
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAvoidAttack(); });
    }

    public override void OnTurnStart()
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnTurnStart(); });
    }

    public override void OnAttackStart(Card targetCharacter)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAttackStart(targetCharacter); });
    }

    public override void OnBeforeBeingAttacked(Character character)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnBeforeBeingAttacked(character); });
    }

    public override void OnAfterBeingAttacked(Character character)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAfterBeingAttacked(character); });
    }

    public override void OnBeforeCounterattack(Character counterTarget)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnBeforeCounterattack(counterTarget); });
    }

    public override void OnAfterCounterattack(Character counterTarget)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAfterCounterattack(counterTarget); });
    }

    public override void OnAttackEnd(Card targetCharacter)
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnAttackEnd(targetCharacter); });
    }

    public override void OnTurnEnd()
    {
        ForEachLifecycle(delegate(Unit lifecycle) { lifecycle.OnTurnEnd(); });
    }

    // Hp变动 增加/减少
    public virtual void changeHp(int incremental)
    {
        _info.Hp += incremental;
    }


    void ForEachLifecycle(Action<Unit> action)
    {
        action.Invoke(magic);
        var childrenComponents = this.GetComponentsInChildren<Unit>();
        foreach (var child in childrenComponents) action.Invoke(child);
        // effectList.ForEach(action.Invoke);
        // buffList.ForEach(action.Invoke);
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
    public void Damage(int damage, bool isPiercing = false)
    {
        OnBeforeDamage(damage);
        OnDamage(damage, isPiercing);
        OnAfterDamage(damage);
    }

    //计算伤害前 时点 
    public virtual void OnBeforeDamage(int damage)
    {
    }

    //伤害计算方法
    public virtual void OnDamage(int damage, bool isPiercing)
    {
        // 是否为穿刺伤害 
        if (isPiercing)
        {
            changeHp(-damage);
        }
        else
        {
            Info.Aegis -= damage;
            // 护盾无法抵消伤害 对溢出伤害进行计算
            if (Info.Aegis < 0)
            {
                changeHp(Info.Aegis);
                Info.Aegis = 0;
            }
        }
    }

    //计算伤害后 时点 确认破坏之前
    public virtual void OnAfterDamage(int damage)
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
            SingleTurnMemo[SingleTurn.Attack] += LastAttackIncrement;
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
            targetCharacter.Damage(Info.Attack, IsPiercing());
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