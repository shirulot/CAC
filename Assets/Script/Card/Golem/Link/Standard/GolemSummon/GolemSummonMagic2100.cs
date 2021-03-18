using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 通用系列 基础包 
/// 999900012100   
/// </summary>
public class GolemSummonMagic2100 : Golem
{
    public override string Name() => "土偶召唤术式";

    public override string Description() => "link:[魔术土偶]";

    private void Awake()
    {
        CardInfo.Init("9999", "0001", 2, 1);
        Info.Init(GolemType.Link, hp: 100, soulLink: 4);
    }


    public override void EffectLaunch()
    {
        Character = GetComponent<SummonSystem>().CharacterSummon<LinkChild>(ChildUnitPrefab, new Vector3(), this);
    }

    //link角色 999900010101
    class LinkChild : Character
    {

        public void Awake()
        {
            CardInfo.Init("9999", "0001", 0, 1,"01");
            Info.Init(attack: 20,score:20);
        }

        public override string Name() => "魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}