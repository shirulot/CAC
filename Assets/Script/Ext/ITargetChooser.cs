using System.Collections.Generic;

public interface ITargetChooser
{
     void EffectPreAction();

     void EffectInvoke(List<Card> targets);
}