//loster

public class AggregatorEffect : Effect
{
    private string _field = "";
    private int _increment = 0;
    private string _seriesId = "";

    public override string Name() => "集结者";

    public override string Description() => $"每当「{_field}」出场时增加{_increment}个特殊指示物";

    public void Init(string fieldName, int increment, string seriesId)
    {
        _field = fieldName;
        _increment = increment;
        _seriesId = seriesId;
    }

    public override void OnCharacterDeath(Character target)
    {
        if (target.CardInfo.seriesId == _seriesId)
        {
            gameObject.GetComponent<Leader>().ChangeSPToken(_increment);
        }
    }
}