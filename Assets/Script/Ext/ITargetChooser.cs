using System.Collections.Generic;

public interface ITargetChooser
{
     void EffectPreAction();

     void EffectAction(List<Card> targets);
}