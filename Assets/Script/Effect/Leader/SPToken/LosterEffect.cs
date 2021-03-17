public class LosterEffect : Effect
{
    private string _field = "";
    private float _increment = 0;
    private string _seriesId = "";

    public override string Name() => $"遗失者「{_field}」";

    public override string Description() => $"每当「{_field}」退场时增加{_increment}个特殊指示物";

    public void Init(string fieldName, int increment, string seriesId)
    {
        _field = fieldName;
        _increment = increment;
        _seriesId = seriesId;
    }

    public override void OnCardBreak(Card card)
    {
        if (card is Character && card.CardInfo.seriesId == _seriesId)
        {
            gameObject.GetComponent<Leader>().ChangeSPToken(_increment);
        }
    }
}