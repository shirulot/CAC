using System.Collections.Generic;

public class MagicMasterEffect : Effect
{
    private string _field = "";
    private float _increment = 0;
    private string _seriesId = "";

    public override string Name() => "魔术掌控";

    public override string Description() => $"每当魔术发动时增加{_increment}个特殊指示物";

    public void Init(string fieldName, int increment, string seriesId)
    {
        _field = fieldName;
        _increment = increment;
        _seriesId = seriesId;
    }

    public override void OnCharacterDeath(Character target)
    {
         gameObject.GetComponent<Leader>().ChangeSPToken(_increment);
    }
}