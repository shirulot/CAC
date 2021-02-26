using System;
using UnityEngine;

//白团子战士
public class WhiteBreadSoldierStandard : Character
{
    public override string Name() => "shiro danko soldier";

    private void Awake()
    {
        CardInfo.Init(seriesId: "0001", groupId: "0001", rank: 1, no: 1);
        State.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 3, maxHp: 10, hp: 10, score: 10);
    }

    public override void CharacterDeath(Player player)
    {
        this.Player = player;
    }

    protected override void EffectAttach()
    {
        var effect = Obj.AddComponent<StrikerEffect>();
        effect.AttachCharacter(this);
    }
}