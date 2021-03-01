using UnityEngine;

public class ChargeSingleCannon : Golem
{
     int count = 1;
     int used = 0;
    
    public void Awake()
    {
        CardInfo.Init("9999", "0001", 3, 8);
        HP = 20;
    }
    
    public override void Charge(int point, Card attacker)
    {
      
    }

    
    
    public override string Name() => "单发式充能炮";
    public override string Description() => $"充能完毕后,对直线单位上所有单位造成10伤害\n[使用次数{used}/{count}]";
}