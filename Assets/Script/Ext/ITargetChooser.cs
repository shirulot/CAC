using System.Collections.Generic;

public interface ITargetChooser
{
     void EffectPreAction();

     void TargetsSelection(List<Card> targets);
}