using System;

public class SPSpecialChargeEffect : Effect
{
    public override string Name() => "SP:特殊充能";

    public override string Description() => "[无法重复] 特殊指示物在30个以上后附加该能力时,上升当前单位攻击力[30]与积分[300]";

    private void Start()
    {
        var leader = gameObject.GetComponent<Leader>();
        var record = leader.UnitLog[Name()];
        if (record != null || leader.SPToken < 30) return;
        leader.ChangeAttack(30);
        leader.ChangePoint(300);
        leader.UnitLog[Name()] = true;
    }
}