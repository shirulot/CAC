//loster

public class AggregatorEffect : Effect
{
    private string _field = "";
    private int _increment = 1;
    private string _seriesId = "";

    public override string Name() => "集结者";

    public override string Description() => $"每当「{_field}」出场时增加{_increment}个特殊指示物";
    public override int Increment()=>Level * _increment;

    public void Init(string fieldName, string seriesId, int level = 1)
    {
        _field = fieldName;
        Level = level;
        _seriesId = seriesId;
    }

    public override void OnCharacterDeath(Character target)
    {
        if (target.CardInfo.seriesId == _seriesId)
        {
            gameObject.GetComponent<Leader>().ChangeSpToken(_increment);
        }
    }
}