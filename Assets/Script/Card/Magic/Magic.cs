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
public class Magic : Card
{
    public virtual MagicType GetMagicType() => MagicType.CounterMagic;

    protected Character holder;

    //手动使用
    public virtual void OnUseEffect()
    {
    }

    public virtual void SetToCharacter(Character target)
    {
        holder = target;
    }
}