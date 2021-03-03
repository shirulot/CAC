using System;

public class OppressHeavyAttackEffect : Effect
{
    public override string Name() => "压迫重击";
    public override string Description() => "攻击[阶级]低于自身的敌人时上升2点攻击力";

    
    private int _increment = 2;


    public override void OnAttackStart(Card targetCharacter)
    {
        if (enabled && AttachTarget.CardInfo.Rank > targetCharacter.CardInfo.Rank)
            AttachTarget.ChangeAttack(_increment);
    }
    
    public override void OnAttackEnd(Card targetCharacter)
    {
        AttachTarget.ChangeAttack(-_increment);
    }
    
}