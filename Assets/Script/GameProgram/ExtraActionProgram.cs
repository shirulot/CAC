using System.Collections.Generic;

public enum ExtraTag
{
    //当前正在操作的角色
    ActionPlayer,

    //当前回合玩家
    ActionTurnPlayer,

    //当前抽的卡
    DrawCard,

    //当前点击/行动的角色
    ActionCharacter,

    //成为攻击/效果的对象
    TargetCharacter,

    // 入场角色
    DeathCharacter,

    // 退场角色
    DisappearCharacter,
}

// 额外程序区 基本用于对关系的暂存
public class ExtraActionProgram
{
    private static ExtraActionProgram _instance;
    private Dictionary<ExtraTag, Unit> _lifecycleMap = new Dictionary<ExtraTag, Unit>();
    private Dictionary<ExtraTag, Player> _playerMap = new Dictionary<ExtraTag, Player>();

    private ExtraActionProgram()
    {
    }

    public static ExtraActionProgram GetInstance() => _instance ?? (_instance = new ExtraActionProgram());

    // 查询返回卡片对象
    public Card FindCard(ExtraTag tag) => (_lifecycleMap[tag] ?? Card.NewBlankCard()) as Card;

    // 查询玩家
    public Player FindPlayer(ExtraTag tag) => _playerMap[tag];

    // 查询buff ability 也可以用于查询卡片
    public Unit FindEffect(ExtraTag tag) => _lifecycleMap[tag] ?? Card.NewBlankCard();

    // 保存
    public void Save(ExtraTag tag, Unit unit)
    {
        _lifecycleMap[tag] = unit;
    }

    public void SavePlayer(ExtraTag tag, Player player)
    {
        _playerMap[tag] = player;
    }

    // 删除
    public void Remove(ExtraTag tag)
    {
        _lifecycleMap.Remove(tag);
    }
}