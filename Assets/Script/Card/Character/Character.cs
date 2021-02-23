using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色卡
public class Character : Card
{
    //魔术
    public Magic magic;

    //当前角色身上的buff
    List<Buff> buffList;

    List<Effect> effectList;

    //单回合攻击力增减等
    protected Dictionary<SingleTurn, int> SingleTurnMemo = new Dictionary<SingleTurn, int>();

    // 攻击力最近一次的增量
    public int LastAttackIncrement = 0;

    public Player Player;
    private CharacterState _state = new CharacterState();

    public Character(Player player)
    {
        this.Player = player;
        EffectAttach();
    }

    public CharacterState State
    {
        get { return _state; }
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

    public override void OnAttackStart(Character targetCharacter)
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

    public override void OnAttackEnd(Character targetCharacter)
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
        _state.Hp += incremental;
    }


    void ForEachLifecycle<TLifecycle>(Action<TLifecycle> action) where TLifecycle : class
    {
        effectList.ForEach(delegate(Effect effect) { action.Invoke(effect as TLifecycle); });
        buffList.ForEach(delegate(Buff buff) { action.Invoke(buff as TLifecycle); });
    }

    //buff 赋予
    public virtual void BuffAttach<T>(T buff) where T : Buff
    {
        Buff existingTarget = null;
        buffList.ForEach(delegate(Buff child)
        {
            // var isInstanceOfType = typeof(T).IsInstanceOfType(child);
            if (child is T)
            {
                existingTarget = child;
            }
        });

        if (existingTarget == null)
        {
            buffList.Add(buff);
            buff.BuffAttach();
        }
        else
        {
            existingTarget.BuffUp(buff);
        }
    }

    //buff清除
    public virtual void BuffDetach(Buff buff)
    {
        try
        {
            buffList.Remove(buff);
            buff.OnBuffDetach();
        }
        catch (Exception e)
        {
            Console.WriteLine("BuffDettach : " + e);
        }
    }

    //伤害计算暂不做过于复杂逻辑 
    public void Damage(int damage, bool isPiercing = false)
    {
        OnBeforeDamage(damage);
        // 是否为穿刺伤害 
        if (isPiercing)
        {
            changeHp(-damage);
        }
        else
        {
            State.Aegis -= damage;
            // 护盾无法抵消伤害 对溢出伤害进行计算
            if (State.Aegis < 0)
            {
                changeHp(State.Aegis);
                State.Aegis = 0;
            }
        }

        OnAfterDamage(damage);
    }

    //计算伤害前 时点 
    public virtual void OnBeforeDamage(int damage)
    {
    }

    //计算伤害后 时点 确认破坏之前
    public virtual void OnAfterDamage(int damage)
    {
    }

    public virtual void ChangeAttack(int incremental)
    {
        State.Attack += incremental;
        LastAttackIncrement = incremental;
    }

    public virtual void AegisChange(int incremental)
    {
        var temp = State.Aegis + incremental;
        State.Aegis = temp <= 0 ? 0 : incremental;
    }


    public virtual void OnAfterMove()
    {
    }

    // 当前角色是否能反击 如果能 被反击角色是否在攻击范围之内
    public virtual bool CanCounterAttack() => false;

    // 连击攻击前
    public virtual void OnBeforeComboHit(Character targetCharacter)
    {
        if (!State.SuperComboHit)
        {
            int lastAttack = State.Attack;
            var decrement = Mathf.FloorToInt(State.Attack / 2f);

            LastAttackIncrement = lastAttack - State.Attack;
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

    public virtual void SingleEffectAttach(Effect effect)
    {
        effectList.Add(effect);
        effect.OnAttach();
    }

    public virtual void AttackTarget(Character target)
    {
        // 伤害结算
        target.Damage(State.Attack, IsPiercing());
    }
}