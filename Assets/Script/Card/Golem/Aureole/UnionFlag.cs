using UnityEngine;

public class UnionFlag : Golem
{
    public override string Name() => "Union Flag";

    public override string Description() => "[UnitedWeStand]";

    private UnitedWeStand unitedWeStand;

    public override void EffectLaunch()
    {
        var golem = GetComponent<SummonSystem>().GolemSummon<UnionFlag>(UnitPrefab, new Vector3());
        unitedWeStand = golem.gameObject.AddComponent<UnitedWeStand>();
        unitedWeStand.Attach(1);
        unitedWeStand.setEnabled(true, GetComponent<PlayerManager>().GetCurrentPlayer());
    }

    public override void ChargeComplete()
    {
        unitedWeStand.AureoleLevelChange(1);
    }
}