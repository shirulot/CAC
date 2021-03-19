using UnityEngine;

//000100033200
public class WhiteBreadPathogen3200 : Character
{
    public override string Name() => "白团子病原体";

    public override string Description() => "[死疫带菌者] [死疫散播者] [恐惧]";

    private void Awake()
    {
        CardInfo.Init("0001", "0003", 3, 2);
        Info.Init(avoid: 5, hitRate: 95, mobility: 4, attack: 10, hp: 100, score: 10);
    }

    protected override void EffectAttach()
    {
        gameObject.AddComponent<DeathDisease>().enable = false;
        gameObject.AddComponent<FearEffect>();
        gameObject.AddComponent<Disseminator<DeathDisease>>().Init("死疫");
    }
    
    
}