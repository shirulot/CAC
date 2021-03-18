public class SPAegis : Effect
{
    private int _base = 0;
    private int _increment = 1;

    public override string Name() => $"SP:Aegis";
    public override string Description() => $"我方结束阶段获得特殊指示物*{Increment()}的Aegis";

    public override int Increment() => _base + _increment * Level;

    public void Init(int level)
    {
        this.Level = level;
    }

    public override void OnTurnEnd()
    {
        if (GetComponent<PlayerManager>().ActivePlayerIsCurrent())
        {
            var leader = gameObject.GetComponent<Leader>();
            leader.AegisChange(leader.SPToken * Increment());
        }
    }
}