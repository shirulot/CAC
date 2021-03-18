using System;
using UnityEngine;

//999900014200
public class UnionFlag : Golem
{
    private void Awake()
    {
        CardInfo.Init("9999", "0001", 4, 2);
        Info.Init(GolemType.Aureole, hp: 100);
    }

    public override string Name() => "同盟旗帜";

    public override string Description() => "[UnitedWeStand]";

    private UnitedWeStand unitedWeStand;

    public override void EffectLaunch()
    {
        var golem = GetComponent<SummonSystem>().GolemSummon<UnionFlag>(UnitPrefab, new Vector3());
        unitedWeStand = golem.gameObject.AddComponent<UnitedWeStand>();
        unitedWeStand.Attach(1);
        unitedWeStand.setEnabled(true, GetComponent<PlayerManager>().GetCurrentPlayer());
    }

    public override void ChargeComplete(Card attacker)
    {
        unitedWeStand.AureoleLevelChange(1);
    }
}