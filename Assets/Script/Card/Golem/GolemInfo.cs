public class GolemInfo
{
    //总共可使用次数
    public int Count = 1;

    // 已使用次数
    public int Used = 0;

    // golem存在hp  
    public int HP;

    // 基础HP
    public int StandradHP;

    // 连接数
    public int SoulLink;

    // 类型
    public GolemType Type;

    public GolemInfo Init(
        GolemType type = GolemType.Link,
        int count = 1,
        int used = 0,
        int HP = 10,
        int standradHP = 10,
        int soulLink = 3
    )
    {
        this.Count = count;
        this.Used = used;
        this.HP = HP;
        this.StandradHP = standradHP;
        this.SoulLink = soulLink;

        return this;
    }
}