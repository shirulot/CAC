
// 000100014100
public class WhiteBreadSoldier4100 : Character
{
    public override string Name() => "白团子战士-完成态";
    public override string Description() => "[前锋][压迫重击]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 4, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 40, hp: 200, score: 30);
    }

    protected override void EffectAttach()
    {
        gameObject.AddComponent<StrikerEffect>();
        gameObject.AddComponent<OppressHeavyAttackEffect>();
    }
}