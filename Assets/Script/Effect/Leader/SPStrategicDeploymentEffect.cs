using System.Collections.Generic;

public class SPStrategicDeployment : Effect, ITargetChooser
{
    private int _base = 0;
    private int _increment = 1;

    public override string Name() => $"SP:战略部署";
    public override string Description() => $"[回合限制]:消耗最多3个特殊指示物 在战场上任意位置放置消费数量的「巨石」";


    public override void OnTurnStart()
    {
        if (GetComponent<PlayerManager>().ActivePlayerIsCurrent())
            gameObject.GetComponent<Leader>().UnitLog[Name()] = null;
    }

    public override void OnTurnEnd()
    {
    }

    public void EffectPreAction()
    {
        if (gameObject.GetComponent<Leader>().UnitLog[Name()] == null)
            GetComponent<EventHandle>().SelectionTarget(this,1,3);
    }

    public void TargetsSelection(List<Card> targets)
    {
        var leader = gameObject.GetComponent<Leader>();
        if (targets == null || targets.Count <= 0) return;
        var count = targets.Count;
        leader.ChangeSpToken(count);
        //TODO 创建巨石
    }
}