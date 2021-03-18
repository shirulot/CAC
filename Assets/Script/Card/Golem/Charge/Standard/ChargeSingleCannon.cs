using UnityEngine;

//999900013800
public class ChargeSingleCannon : Golem
{
    public void Awake()
    {
        CardInfo.Init("9999", "0001", 3, 8);
        Info.Init(GolemType.Charge, hp: 200, chargeBase: 200, soulLink: 3);
    }

    private int _damage = 100;
    //每次充能完成调用
    public override void ChargeComplete(Card attacker)
    {
        //对直线所有敌人造成15伤害
        var list = GetComponent<Field>().FindLineUnit(this);
        list.ForEach(delegate(Character character) { character.Damage(15,this); });
    }

    public override string Name() => "单发式充能集数炮";
    public override string Description() => $"充能完毕后,对直线单位上所有单位造成{_damage}伤害\n[使用次数 {Info.Used}/{Info.Count}]";
}