using System.Collections.Generic;

public enum MagicType
{
    InstantMagic,
    CounterMagic
}

/// <summary>
/// 魔术卡
/// 魔术的设计原则
/// 【即时魔术 自己回合发动,直接生效】
/// 【反击魔术 安放之后再特定时期触发】
/// </summary>
public class Magic : Card,ITargetChooser
{
    public virtual MagicType GetMagicType() => MagicType.CounterMagic;

    protected Character holder;
    
    // 能力预发动 通常是用于选中对象等
    public virtual void EffectPreAction()
    {
        EffectInvoke(null);
    }
    
    
    // 能力发动
    public virtual void EffectInvoke(List<Card> targets)
    {
    }

    // 角色持有
    public virtual void SetToCharacter(Character target)
    {
        holder = target;
    }
}