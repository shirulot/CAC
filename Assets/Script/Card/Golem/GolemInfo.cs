public class GolemInfo
{
    //总共可使用次数
    public int Count = 1;

    // 已使用次数
    public int Used = 0;

    // golem存在hp  
    public int Hp;

    // 基础HP
    public int ChargeBase;

    // 连接数
    public int SoulLink;

    //破坏损失的分数
    public int Score;

    // 类型
    public GolemType Type = GolemType.Link;

    public GolemInfo Init(
        GolemType type = GolemType.Link,
        int count = 1,
        int used = 0,
        int hp = 100,
        int chargeBase = 100,
        int soulLink = 3,
        int score = 0
    )
    {
        this.Count = count;
        this.Used = used;
        this.Hp = hp;
        this.ChargeBase = chargeBase;
        this.SoulLink = soulLink;
        this.Score = score;
        return this;
    }
}