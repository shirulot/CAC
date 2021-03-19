public class FearEffect : Effect
{
    public override string Name() => "恐惧";

    public override string Description() => "被攻击对象无法反击";

    int _targetLastCanCounter = 2;

    public override void OnAttackStart(Card targetCard)
    {
        if (!(targetCard is Character target) || target.Info.IsBreak) return;
        _targetLastCanCounter = target.Info.CanCounter ? 1 : 0;
        target.Info.CanCounter = false;
    }

    public override void OnAttackEnd(Card targetCharacter)
    {
        if (!(targetCharacter is Character target) || target.Info.IsBreak || _targetLastCanCounter == 2) return;
        target.Info.CanCounter = _targetLastCanCounter == 1;
        _targetLastCanCounter = 2;
    }
}