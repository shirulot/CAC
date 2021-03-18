public class SPAegis:Effect
{
    private int _increment;
    public override string Name()=>"SP:Aegis";
    public override string Description() => $"我方结束阶段获得特殊指示物*{_increment}的Aegis";

    public void Init(int increment)
    {
        this._increment = increment;
    }

    public override void OnTurnEnd()
    {
        if (GetComponent<PlayerManager>().ActivePlayerIsCurrent())
        {
            var leader = gameObject.GetComponent<Leader>();
            leader.AegisChange(leader.SPToken*_increment);
        }
    }
}