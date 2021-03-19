using System;

public class OppressHeavyAttackEffect : Effect
{
    public override string Name() => "压迫重击";
    public override string Description() => $"与[阶级]低于自身的敌人战斗前上升{Increment()}点攻击力";
    public override int Increment()=>2;

    // public int Level = 1;
    // private int _increment = 1;


    public override void OnAttackStart(Card targetCard)
    {
        if (enabled && AttachTarget.CardInfo.Rank > targetCard.CardInfo.Rank)
            AttachTarget.ChangeAttack(Increment());
    }
    
    public override void OnAttackEnd(Card targetCharacter)
    {
        AttachTarget.ChangeAttack(-Increment());
    }
    
}