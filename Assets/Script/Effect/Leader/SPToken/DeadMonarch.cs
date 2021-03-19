public class DeadMonarchEffect : Effect
{
    private int _increment = 1;

    public override string Name() => "死物君主";

    public override string Description() => $"每当角色单位退场时增加{_increment}个特殊指示物";
    public override int Increment()=>_increment*Level;

    public void Init(int level)
    {
        Level = level;
    }

    public override void OnCardBreak(Card card, Unit breaker)
    {
        if (card is Character ) gameObject.GetComponent<Leader>().ChangeSpToken(_increment);
    }
}