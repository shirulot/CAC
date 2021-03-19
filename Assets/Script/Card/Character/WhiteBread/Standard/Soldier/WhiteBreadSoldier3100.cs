
//000100013100
public class WhiteBreadSoldier3100 :Character
{
    public override string Name() => "白团子战士-三型";
    public override string Description() => "[前锋]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 3, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 30, hp: 150, score: 30);
    }
    
    protected override void EffectAttach()
    {
         gameObject.AddComponent<StrikerEffect>();
    }
}