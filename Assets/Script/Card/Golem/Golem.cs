//魔像


using UnityEngine;

public enum GolemType
{
    // 连接型:存在link角色 主体主要为占位单位。只有主体会接受伤害 HP为0时破坏图腾以及角色单位 
    Link,

    // 光环型:为特定条件下的角色附加buff，主体为图腾 HP为0时破坏
    Aureole,

    // 充能型:初始存在较高HP 只接受自己角色的攻击,HP为0时破坏 破坏时发动强力效果
    Charge,
    //TODO 待决策 载具型: 存在普通HP 拥有较远的攻击范围 需要驾驶员 在有驾驶员时不会受到攻击
    //TODO 待决策 攻击型: 存在较低HP 拥有较远的攻击范围 强攻击
}

// 通常因为位置原因 golem的破坏难度比通常角色要高(尤其是link型)  所以golem可以适当的提升破坏score
public class Golem : Card
{
    
    // 被充能破坏
    public bool ChargeBreack = false;

    // 角色
    public Character Character;

    //Character 预制体 SoulLink对象需要使用
    [SerializeField] public GameObject ChildUnitPrefab;

    public GolemInfo Info = new GolemInfo();

    public override void OnTurnStart()
    {
        //回合开始时进行 如果魔像持有子角色 则进行SoulLink检查
        if (Character != null) _linkCheck();
    }

    // soulLink检查 如果无法达到连接则给予魔像伤害 并且回收魔像单位
    // 同时检查link角色是否在该魔像连接格 如果是 也进行回收并进行伤害结算
    private void _linkCheck()
    {
        if (Info.Type == GolemType.Link)
        {
            //回合开始时检查
            //TODO mock 
            bool isLink = Random.Range(0, 1) != 1;
            if (isLink)
            {
                ShowLinkAnim();
            }
            else
            {
                Charge(Info.SoulLink, Character);
                Info.SoulLink--;
            }
        }
    }

    // link 成功后亮起地板
    protected void ShowLinkAnim()
    {
    }


    public void OnBeforeDamage()
    {
    }

    public void OnAfterDamage()
    {
    }

    //充能（受到伤害） 
    public void Charge(int point, Card attacker)
    {
        var isCurrent = GetComponent<PlayerManager>().CardIsCurrentPlayerProperty(attacker);
        Info.Hp = isCurrent ? Info.Hp - point : Info.Hp + point;
        if (Info.Hp <= 0)
        {
            Info.Hp = Info.ChargeBase;
            ChargeComplete(attacker);
            Info.Used++;
        }
        if (Info.Hp >= Info.ChargeBase * 2 || Info.Used >= Info.Count) GolemBreak(attacker);
    }

    //单次充能完成发动的能力
    public virtual void ChargeComplete(Card breaker)
    {
        Info.Used++;
        ChargeBreack = true;
        //破坏时将事件传递给所有单位
        foreach (var t in GetComponents<Card>()) t.OnChargeComplete(this);
        GolemBreak(breaker);
    }

    /// 魔像破坏 
    /// <param name="breaker"> 破坏当前魔像的对象 </param>
    public void GolemBreak(Card breaker)
    {
        //破坏时将事件传递给所有单位
        foreach (var t in GetComponents<Card>()) t.OnGolemBreak(breaker, this);
    }
}