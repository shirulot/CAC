public class BaseLinkChild : Character
{
    public override void OnDamage(int damage, Unit piercing, bool isPiercing, bool breakIsLock)
    {
        // 不对SoulLink的魔像子角色进行伤害计算(无敌)
        // 不做特殊效果时该方法保持空实现

    }

    // 附加 魔像幻影 buff(说明性buff)
    public override void CharacterDeath()
    {
        var golemPhantom = gameObject.AddComponent<GolemPhantom>();
    }
}