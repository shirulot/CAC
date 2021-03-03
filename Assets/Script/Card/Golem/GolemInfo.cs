public class GolemInfo
{
    //总共可使用次数
    public int Count = 1;

    // 已使用次数
    public int Used = 0;

    // golem存在hp  
    public int Hp;

    // 基础HP
    public int StandardHp;

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
        int hp = 10,
        int standardHp = 10,
        int soulLink = 3,
        int score = 0
    )
    {
        this.Count = count;
        this.Used = used;
        this.Hp = hp;
        this.StandardHp = standardHp;
        this.SoulLink = soulLink;
        this.Score = score;
        return this;
    }
}