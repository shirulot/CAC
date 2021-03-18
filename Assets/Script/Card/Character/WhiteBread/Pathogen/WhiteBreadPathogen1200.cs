using UnityEngine;

//
public class WhiteBreadPathogen1200 : Character
{
    public override string Name() => "白团子带菌者";
    
    public override string Description()=>"[死疫带菌者]:[固有]出场后携带[死疫]";
    
    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 2);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 30, hp: 50, score: 10);
    }
    
    
    
}