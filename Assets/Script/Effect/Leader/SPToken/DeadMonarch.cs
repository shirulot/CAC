public class DeadMonarchEffect : Effect
{
    private int _increment = 0;

    public override string Name() => "死物君主";

    public override string Description() => $"每当角色单位退场时增加{_increment}个特殊指示物";

    public void Init(int increment)
    {
        _increment = increment;
    }

    public override void OnCardBreak(Card card)
    {
        if (card is Character ) gameObject.GetComponent<Leader>().ChangeSPToken(_increment);
    }
}