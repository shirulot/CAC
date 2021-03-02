using System.Collections.Generic;

public class Hand
{
    //通常抽卡数
    int NormalDrawCount = 0;
    //额外抽卡数
    int ExtDrawCount = 0;
    //因效果加入手牌张数
    int AddCount = 0;
    //回收张数
    int GetBackCount = 0;
    
    
    private List<Card> _list = new List<Card>();

    // 通常抽牌
    public void CardDraw(Card card)
    {
        _list.Add(card);
        NormalDrawCount++;
    }

    //额外抽卡
    public void CardExtDraw(Card card)
    {
        _list.Add(card);
        ExtDrawCount++;
    }

    // 取回寄存
    public void DepositGetBack(List<Card> depositList)
    {
        _list.AddRange(depositList);
        GetBackCount++;
    }

    // 因为效果加入手牌
    public void AddHand(Card card)
    {
        _list.Add(card);
        AddCount++;
    }
}