using UnityEngine;

public class ChargeSingleCannon : Golem
{
    

    public void Awake()
    {
        CardInfo.Init("9999", "0001", 3, 8);
        Info.Init(GolemType.Charge,HP:20,standradHP:20,soulLink:3);
    }

    public override void Charge(int point, Card attacker)
    {
        
    }

    //每次充能完成调用
    public override void ChargeComplete()
    {
        
    }

   


    public override string Name() => "单发式充能炮";
    public override string Description() => $"充能完毕后,对直线单位上所有单位造成10伤害\n[使用次数{Info.Used}/{Info.Count}]";
}