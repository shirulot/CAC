public class WhiteBreadSoldier200 :Character
{
    
    
    public override string Name() => "白团子战士-二型";
    public override string Description() => "[前锋]";
    
    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 2, maxHp: 13, hp: 13, score: 15);
    }
    
    protected override void EffectAttach()
    {
        gameObject.AddComponent<StrikerEffect>();
    }
}