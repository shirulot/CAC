
using System;

/// <summary>
/// 通用系列 基础包 
/// 9999 0001  
/// </summary>
public class GolemSummonMagic :Golem
{
    public override string Name() => "土偶召唤术式";

    public override string Description() => "link:[魔术土偶]";
    
    private void Awake()
    {
        CardInfo.Init("9999","0001",2,1);
    }

    //link角色
    class LinkChild : Character
    {
        public override void CharacterDeath(Player player)
        {
            CardInfo.Init("9999","0001",0,1);
        }


        public override string Name() => "魔术土偶";

        public override string Description() => "SoulLink系统试做型单元";
    }
}

