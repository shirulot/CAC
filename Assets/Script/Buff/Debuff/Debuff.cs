public class Debuff : Buff
{
    public Debuff(Character attachTarget) : base(attachTarget)
    {
    }

    public override BuffType buffType()
    {
        return BuffType.DeBuff;
    }
}