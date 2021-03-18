using System.Collections.Generic;

public class MagicMasterEffect : Effect
{
    private int _increment = 0;

    public override string Name() => "魔术掌控";

    public override string Description() => $"每当魔术发动时增加{_increment}个特殊指示物";

    public void Init( int increment)
    {
        _increment = increment;
    }

    public override void OnCharacterDeath(Character target)
    {
         gameObject.GetComponent<Leader>().ChangeSPToken(_increment);
    }
}