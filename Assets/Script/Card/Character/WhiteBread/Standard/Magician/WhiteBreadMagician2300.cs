
// 000100012300
public class WhiteBreadMagician2300 : Character
{
    
    public override string Name() => "白团子魔术师-中阶";
    public override string Description() => "[魔术掌控]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 2, 3);
        Info.Init(avoid: 15, hitRate: 95, mobility: 3, attack: 30,  hp: 60, score: 10);
    }
    
    
    
}