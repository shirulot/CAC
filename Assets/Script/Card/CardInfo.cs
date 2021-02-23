using System;

public class CardInfo
{
    // 组号 用于前缀 避免扩展情况下的卡片重复 通常为4位 1000-9999
    public String groupId;

    // 系列编号 通常为4位 1000-9999
    public String seriesId;

    // 特殊码 用于区分不同世代的卡 两位 从10-99 
    public String specialCode;

    // 卡片编号 组号+系列编号+阶级+卡位+特殊码 列: 100010001810
    public String cardId;

    //------------------ 卡片效果会涉及阶级、编号 以下为常用字段 -------------------
    // 阶级 通常为1-4  预留0阶位为token、额外卡 特殊阶级 5阶卡位特殊卡
    public  int Rank;

    // 卡位1位 0-9
    public int No;

    // 游戏Id
    public int activeId;

    public void Init(String seriesId = "0000", String groupId = "0000", int rank = 0, int no = 0, String specialCode = "00")
    {
        // 阶
        this.Rank = rank;
        // 1位
        this.No = no;
        //特殊码
        this.specialCode = specialCode;
        //系列id
        this.seriesId = seriesId;
        // 组id
        this.groupId = groupId;
        // 在游戏进行时采用的活动id 每个玩家一张
        this.activeId = rank * 10 + no;
        // 卡片id
        this.cardId = $"{seriesId}{groupId}{this.Rank}{this.No}{specialCode}";
    }
}