using UnityEngine;

////000100032200
public class WhiteBreadPathogen2200 : Character
{
    public override string Name() => "白团子病原体";
    
    public override string Description()=>"[死疫病源] [死疫散播者]";
    
    private void Awake()
    {
        CardInfo.Init("0001", "0003", 2, 2);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 10, hp: 70, score: 10);
    }

    protected override void EffectAttach()
    {
        //添加死疫 并且禁用死疫
        gameObject.AddComponent<DeathDisease>().enable = false;
        gameObject.AddComponent<Disseminator<DeathDisease>>().Init("死疫");
        // gameObject.AddComponent<FearEffect>();
        
    }
    
    
}