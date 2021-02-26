
using System;
using UnityEditor.SceneManagement;

/// <summary>
/// 通用系列 基础包 
/// 9999 0001  
/// </summary>
public class SimpleGolemSummonMagic :Golem
{
    public override string Name() => "简易土偶召唤术式";

    public override string Description() => "link:[简易魔术土偶]";
    
    private void Awake()
    {
        CardInfo.Init("9999","0001",1,1);
    }

    public override void EffectLaunch()
    {
        Character = GetComponent<MainProgram>().Summon<SimpleGolemSummonMagic.LinkChild>(this);
    }

    //link角色
    class LinkChild : BaseLinkChild
    {
        private void Awake()
        {
            CardInfo.Init("9999","0001",0,1);
            State.Init(attack:2,score:15);
        }


        public override string Name() => "简易魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
        
        
    }
}

