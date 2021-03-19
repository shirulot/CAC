using System.Collections.Generic;

public class SPLifeRestoreEffect : Effect, ITargetChooser
{
    private int _increment = 1;
    private int _base = 0;
    public int cost = 0;

    public override string Name() => $"SP:生命充能";

    public override string Description() => $"消耗N个特殊指示物,指定场地上的一个单位,恢复N*{Increment()}点HP";
    public override int Increment() => _base + Level * _increment;

    public void Init(int level = 1)
    {
        this.Level = level;
    }


    public void EffectPreAction()
    {
        //TODO Dialog让用户选择数量后
        cost = 10;
        var leader = gameObject.GetComponent<Leader>();
        if (cost > leader.SPToken)
        {
            return;
        }
        else
        {
            GetComponent<EventHandle>().SelectionTarget(this, 1, 1);
        }
    }

    public void TargetsSelection(List<Card> targets)
    {
        if (targets == null || targets.Count <= 0 || !(targets[0] is Character ca)) return;
        gameObject.GetComponent<Leader>().ChangeSpToken(-cost);
        ca.ChangeHp(cost * Increment());
    }
}