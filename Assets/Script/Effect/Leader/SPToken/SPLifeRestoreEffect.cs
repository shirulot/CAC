using System.Collections.Generic;

public class SPLifeRestoreEffect : Effect, ITargetChooser
{
    private int _increment = 0;
    public int cost = 0;

    public override string Name() => "SP:生命充能";

    public override string Description() => $"消耗N个特殊指示物,指定场地上的一个单位,恢复N*{_increment}点HP";

    public void Init(int increment)
    {
        this._increment = increment;
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
        gameObject.GetComponent<Leader>().ChangeSPToken(-cost);
        ca.ChangeHp(cost * _increment);
    }
}