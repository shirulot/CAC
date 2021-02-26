public class Gain : Buff
{
    public override void Attach(Character attachTarget)
    {
        this.attachTarget = attachTarget;
    }

    public override BuffType buffType()
    {
        return BuffType.Gain;
    }
}