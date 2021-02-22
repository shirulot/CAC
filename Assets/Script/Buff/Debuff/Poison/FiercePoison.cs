using System;

/// <summary>
/// 普通 
/// </summary>
public class FiercePoison : Buff, IPoison
{
    public FiercePoison(Character attachTarget) : base(attachTarget)
    {
    }

    private int _baseDamage = 1;
    private int _growthDamage = 1;

    public override string Name() => "猛毒";

    public override string Description() => "回合开始时根据中毒等级造成伤害" +
                                            $"\n下次造成结算时{_baseDamage + _growthDamage * buffLevel}伤害";

    //伤害幅度为 2 3 4 5 6 ...
    public override void OnTurnStart()
    {
        if (enable) attachTarget.Damage(_baseDamage + _growthDamage * buffLevel);
        BuffDown();
    }
}