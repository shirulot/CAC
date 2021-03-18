using System;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// 通用系列 基础包 
/// 999900011100   
/// </summary>
public class GolemSummonMagic1100 : Golem
{
    public override string Name() => "简易土偶召唤术式";

    public override string Description() => "link:[简易魔术土偶]";

    private void Awake()
    {
        CardInfo.Init("9999", "0001", 1, 1);
        Info.Init(GolemType.Link, hp: 70, soulLink: 3);
    }

    public override void EffectLaunch()
    {
        Character = GetComponent<SummonSystem>()
            .CharacterSummon<GolemSummonMagic1100.LinkChild>(ChildUnitPrefab, new Vector3(), this);
    }

    //link角色 999900010100 
    class LinkChild : BaseLinkChild
    {
        private void Awake()
        {
            CardInfo.Init("9999", "0001", 0, 1);
            Info.Init(attack: 10,score:20);
        }


        public override string Name() => "简易魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}