using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    //卡组
    public Deck Deck;

    // 分数 用于最终结算游戏胜败(考虑基本分)
    public int Score = 500;

    // 手牌
    public readonly Hand Hand = new Hand();

    //行动点
    public int ActionPoint = 100;

    // 最大行动点
    public int MaxActionPoint = 100;

    //当前玩家的行动顺序号
    public int Order;

    // 本体
    public Leader ontology;

    //选择本体
    public void SelectionLeader()
    {
        //TODO 让用户选择本体   .....
    }

    // type where : Leader
    public void TakePartInGame(Type type)
    {
        ontology = (Leader) gameObject.AddComponent(type);
    }

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
        //TODO 点数浮动动画
        if (MaxActionPoint > 50) MaxActionPoint += Random.Range(-10, 10);
        else if (MaxActionPoint < 50) MaxActionPoint += Random.Range(0, 10);
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

    //分数变更 
    public void ScoreChange(int point)
    {
        Score += point;
    }

    //初始化该玩家的卡组
    public void InitDeck()
    {
    }


    public void OnTurnEnd()
    {
        _isCurrent();
    }

    public void OnCardDraw()
    {
        CardDrawAnim(_isCurrent());
    }

    private void CardDrawAnim(bool isCurrent)
    {
    }

    public void OnTurnStart()
    {
        if (_isCurrent()) NewTurn();
    }

    //当前是否为回合进行中的玩家
    private bool _isCurrent()
    {
        var pm = GetComponent<PlayerManager>();
        return pm.ActiveIndex == pm.CurrentIndex;
    }

    //TODO
    public Character[] GetCharacters()
    {
        return new Character[] { };
    }

    //TODO 
    public void SettlementDamagePoint(Card card, int score)
    {
        Score -= score;
    }
}