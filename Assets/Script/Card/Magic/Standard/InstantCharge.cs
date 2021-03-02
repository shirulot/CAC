//高速充能

using System;
using System.Collections.Generic;

public class InstantCharge : Magic
{
    private void Awake()
    {
        CardInfo.Init("9999", "0001", 4, 3);
    }

    public override void EffectAction(List<Card> targets)
    {
        if (targets.Count > 0 && targets[0] is Golem target && target.Info.Type == GolemType.Charge)
            target.Charge(10, this);
    }

    public override string Name() => "高速充能";

    public override string Description() => "指定场地上一个充能型魔像,对其造成10点伤害(如果是敌方单位,则为逆充能)";
}