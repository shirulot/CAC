public class WhiteBreadSoldier400 : Character
{
    public override string Name() => "白团子战士-完成态";
    public override string Description() => "[前锋][压迫重击]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 4, maxHp: 20, hp: 20, score: 30);
    }

    protected override void EffectAttach()
    {
        gameObject.AddComponent<StrikerEffect>();
        gameObject.AddComponent<OppressHeavyAttackEffect>();
    }
}