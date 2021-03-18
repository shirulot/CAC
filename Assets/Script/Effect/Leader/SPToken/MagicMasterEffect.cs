using System.Collections.Generic;

public class MagicMasterEffect : Effect
{
    private int _increment = 1;

    public override string Name() => "魔术掌控";

    public override string Description() => $"每当魔术发动时增加{Increment()}个特殊指示物";
    public override int Increment() => _increment * Level;

    public void Init(int level)
    {
        Level = level;
    }

    public override void OnCharacterDeath(Character target)
    {
        gameObject.GetComponent<Leader>().ChangeSPToken(Increment());
    }
}