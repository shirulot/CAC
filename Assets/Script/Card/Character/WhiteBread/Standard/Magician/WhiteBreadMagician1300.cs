
// 000100011300
public class WhiteBreadMagician1300 : Character
{
    
    public override string Name() => "白团子魔术师";
    public override string Description() => "";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 3);
        Info.Init(avoid: 15, hitRate: 95, mobility: 3, attack: 30,  hp: 60, score: 10);
    }

    
}