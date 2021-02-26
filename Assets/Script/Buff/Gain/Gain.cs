public class Gain : Buff
{
    public Gain(Character attachTarget) 
    {
    }

    public override BuffType buffType()
    {
        return BuffType.Gain;
    }
}