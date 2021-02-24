//魔像


public enum GolemType
{
    // 连接型:存在link角色 主体主要为占位单位。只有主体会接受伤害 HP为0时破坏图腾以及角色单位
    Link,

    // 光环型:为特定条件下的角色附加buff，主体为图腾 HP为0时破坏
    Aureole,
    
    // 充能型:初始存在较高HP 只接受自己角色的攻击,HP为0时破坏 破坏时发动强力效果
    Charge,
    //TODO 载具型: 存在普通HP 拥有较远的攻击范围 需要驾驶员 在有驾驶员时不会受到攻击
    //TODO 攻击型: 存在较低HP 拥有较远的攻击范围 强攻击
}

public class Golem : Card
{
    // golem存在hp  
    public int HP = 10;

    // 连接数
    public int SoulLink;

    // 角色
    public Character Character;

    // 类型
    public GolemType Type;

    // 光环
    public Aureole Aureole;

    public override void OnTurnStart()
    {
        //回合开始时进行 如果魔像持有子角色 则进行SoulLink检查
        if (Character != null) _linkCheck();
    }

    // soulLink检查 如果无法达到连接则给予魔像伤害 并且回收魔像单位
    // 同时检查link角色是否在该魔像连接格 如果是 也进行回收并进行伤害结算
    private void _linkCheck()
    {
        //回合开始时检查
    }

    public void Damage(int damage)
    {
        OnBeforeDamage();
        HP -= damage;
        OnAfterDamage();
        if (HP <= 0) Break();
        
    }

    public void OnBeforeDamage()
    {
    }

    public void  OnAfterDamage()
    {
        
    }

    public void Break()
    {
        //角色破坏 
        MainProgram.Instance.Break(this);
    }
}