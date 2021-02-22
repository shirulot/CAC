using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour
{
    //卡组
    public Deck Deck;

    // 分数 用于最终结算游戏胜败
    public int Score = 100;

    // 手牌
    public Hand Hand = new Hand();

    //行动点
    public int ActionPoint = 100;

    // 最大行动点
    public int MaxActionPoint = 100;

    // 光环
    private List<Aureole> AureoleList = new List<Aureole>();

    //抽卡
    public void CardDraw()
    {
        Deck.CardDraw(Hand);
        // var card = deck[0];
        // hand.Add(card);
        // deck.RemoveAt(0);
    }

    // 行动点浮动
    public void ActionPointFloat()
    {
        if (MaxActionPoint > 50)
        {
            MaxActionPoint += Random.Range(-10, 10);
        }
        else if (MaxActionPoint < 50)
        {
            MaxActionPoint += Random.Range(0, 10);
        }
    }

    //回合开始
    public void NewTurn()
    {
        ActionPoint = MaxActionPoint;
    }

    //点数变更 消费/回复
    public void PointChange(int point)
    {
        ActionPoint += point;
    }

    public void setAureoleEnable(Aureole target, bool enable)
    {
        var hasTarget = AureoleList.Contains(target);
        if (enable)
        {
            if (!hasTarget)
            {
                AureoleList.Add(target);
            }

            target.setEnabled(enable, this);
        }
    }
    
    
    //分数变更 
    public void ScoreChange(int point)
    {
        Score += point;
    }

    //初始化该玩家的卡组
    public void InitDeck()
    {
        
    }
}