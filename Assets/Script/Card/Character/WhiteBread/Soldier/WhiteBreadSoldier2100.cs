
// 000100011100
public class WhiteBreadSoldier2100 :Character
{
    public override string Name() => "白团子战士-二型";
    public override string Description() => "[前锋]";
    
    private void Awake()
    {
        CardInfo.Init("0001", "0001", 2, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 20,  hp: 130, score: 20);
    }
    
    protected override void EffectAttach()
    {
        gameObject.AddComponent<StrikerEffect>();
    }
}