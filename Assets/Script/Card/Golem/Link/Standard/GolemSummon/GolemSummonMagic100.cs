using System;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// 通用系列 基础包 
/// 9999 0001  
/// </summary>
public class GolemSummonMagic100 : Golem
{
    public override string Name() => "简易土偶召唤术式";

    public override string Description() => "link:[简易魔术土偶]";

    private void Awake()
    {
        CardInfo.Init("9999", "0001", 1, 1);
        Info.Init(GolemType.Link, hp: 7, soulLink: 3,score:15);
    }

    public override void EffectLaunch()
    {
        Character = GetComponent<SummonSystem>()
            .CharacterSummon<GolemSummonMagic100.LinkChild>(ChildUnitPrefab, new Vector3(), this);
    }

    //link角色
    class LinkChild : BaseLinkChild
    {
        private void Awake()
        {
            CardInfo.Init("9999", "0001", 0, 1);
            Info.Init(attack: 1);
        }


        public override string Name() => "简易魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}