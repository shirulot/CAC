using System.Collections.Generic;

public class FrightenedMagic : Magic
{
    public override MagicType GetMagicType() => MagicType.CounterMagic;

    public override bool IsSingle() => true;

    public FrightenedMagic()
    {
        CardInfo.Init("9999", "0001", 3, 3);
    }


    // 选择需要携带的对象
    public override void EffectPreAction()
    {
        GetComponent<EventHandle>().SelectionTarget(this, 1, 1);
    }

    // 对对象进行携带
    public override void TargetsSelection(List<Card> targets)
    {
        if (targets != null && targets.Count > 0) (targets[0] as Character)?.MagicAttach(this);
    }

    public override void OnBeforeBeingAttacked(Character character)
    {
        character.Damage(3);
    }

    public override string Name() => "惊吓魔术";

    public override string Description() => "cost:10\n持有单位[被攻击前]给予攻击者3点伤害";
}