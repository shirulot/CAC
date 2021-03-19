using System;
using UnityEngine;

//白团子战士 000100011100
public class WhiteBreadSoldier1100 : Character
{
    
    public override string Name() => "白团子战士";
    public override string Description() => "[前锋]";

    private void Awake()
    {
        CardInfo.Init("0001", "0001", 1, 1);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 10,  hp: 100, score: 10);
    }

    public override void CharacterDeath()
    {
    }

    protected override void EffectAttach()
    {
        gameObject.AddComponent<StrikerEffect>();
    }
}