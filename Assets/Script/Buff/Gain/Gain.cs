public class Gain : Buff
{
    public Gain(Character attachTarget) : base(attachTarget)
    {
    }

    public override BuffType buffType()
    {
        return BuffType.Gain;
    }
}