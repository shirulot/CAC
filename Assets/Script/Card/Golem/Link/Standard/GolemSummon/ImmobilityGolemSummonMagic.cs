using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 通用系列 基础包 
/// 9999 0001  
/// </summary>
public class ImmobilityGolemSummonMagic : Golem
{
    public override string Name() => "静默型土偶召唤术式";

    public override string Description() => "link:[复合型魔术土偶]";

    private void Awake()
    {
        CardInfo.Init("9999", "0001", 4, 1);
        HP = 15;
        SoulLink = 5;
    }


    public override void EffectLaunch()
    {
        Character = GetComponent<SummonSystem>().CharacterSummon<LinkChild>(ChildUnitPrefab, new Vector3(), this);
    }

    //link角色
    class LinkChild : Character
    {

        public void Awake()
        {
            CardInfo.Init("9999", "0001", 0, 1,"03");
            State.Init(attack: 5, score: 35);
        }

        public override string Name() => "不动土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}