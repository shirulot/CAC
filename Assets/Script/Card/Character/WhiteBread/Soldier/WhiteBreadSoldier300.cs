public class WhiteBreadSoldier300 :Character
{
    public override string Name() => "白团子战士-三型";
    public override string Description() => "[前锋]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 3, maxHp: 15, hp: 15, score: 20);
    }
    
    protected override void EffectAttach()
    {
         gameObject.AddComponent<StrikerEffect>();
       

    }
}