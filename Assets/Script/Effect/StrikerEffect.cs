

//前锋 

using UnityEngine.UIElements;

public class StrikerEffect : Effect
{
    public override string Name() => "前锋";
    //附加时触发一次 本次结算完成后该能力为白板能力
    public override string Description() => "当前单位召唤时,提升[攻击力]x1、[生命]x2";


    public override void OnAttach()
    {
        if (AttachTarget.Info.EffectEnable)
        {
            AttachTarget.ChangeAttack(1);
            AttachTarget.changeHp(2);
        }
    }
}