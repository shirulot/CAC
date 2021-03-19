public class LosterEffect : Effect
{
    private string _field = "";
    private int _increment = 1;
    private string _seriesId = "";

    public override string Name() => $"遗失者「{_field}」";

    public override string Description() => $"每当「{_field}」退场时增加{_increment}个特殊指示物";
    public override int Increment() => Level * _increment;

    public void Init(string fieldName, int level, string seriesId)
    {
        _field = fieldName;
        Level = level;
        _seriesId = seriesId;
    }

    public override void OnCardBreak(Card card, Unit breaker)
    {
        if (card is Character && card.CardInfo.seriesId == _seriesId)
        {
            gameObject.GetComponent<Leader>().ChangeSpToken(Increment());
        }
    }
}