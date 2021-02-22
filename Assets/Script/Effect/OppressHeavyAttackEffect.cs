public class OppressHeavyAttackEffect : Effect
{
    public override string Name() => "压迫重击";
    public override string Description() => "攻击[阶级]低于自身的敌人时上升2点攻击力";

    public OppressHeavyAttackEffect(Character attachTarget) : base(attachTarget)
    {
    }

    private int _increment = 2;

    public override void OnAttackStart(Character targetCharacter)
    {
        if (enabled && attachTarget.CardInfo.Rank > targetCharacter.CardInfo.Rank)
            attachTarget.ChangeAttack(_increment);
    }
    
    public override void OnAttackEnd(Character targetCharacter)
    {
        attachTarget.ChangeAttack(-_increment);
    }
    
}