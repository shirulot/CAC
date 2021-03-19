using UnityEngine;

//000100031200
public class WhiteBreadPathogen1200 : Character
{
    public override string Name() => "白团子带菌者";
    
    public override string Description()=>"[死疫病源]";
    
    private void Awake()
    {
        CardInfo.Init("0001", "0003", 1, 2);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 10, hp: 50, score: 10);
    }

    protected override void EffectAttach()
    {
        gameObject.AddComponent<DeathDisease>().enable = false;
    }
}