public class BaseLinkChild : Character
{
    public override void OnDamage(int damage, bool isPiercing)
    {
        //不对SoulLink的魔像子角色进行伤害计算(无敌)
    }

    // 附加魔像幻影buff(说明性buff)
    public override void CharacterDeath(Player player)
    {
        var golemPhantom = Obj.AddComponent<GolemPhantom>();
        BuffAttach<GolemPhantom>(1);
    }
}