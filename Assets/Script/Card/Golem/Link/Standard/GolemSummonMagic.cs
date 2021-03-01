using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 通用系列 基础包 
/// 9999 0001  
/// </summary>
public class GolemSummonMagic : Golem
{
    public override string Name() => "土偶召唤术式";

    public override string Description() => "link:[魔术土偶]";

    private void Awake()
    {
        CardInfo.Init("9999", "0001", 2, 1);
        HP = 7;
        SoulLink = 3;
    }

    //Character 预制体
    [SerializeField] GameObject MagicGolemPrefab;

    public override void EffectLaunch()
    {
        Character = GetComponent<SummonSystem>().CharacterSummon<LinkChild>(MagicGolemPrefab, new Vector3(), this);
    }

    //link角色
    class LinkChild : Character
    {

        public void Awake()
        {
            CardInfo.Init("9999", "0001", 0, 1);
        }

        public override string Name() => "魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}