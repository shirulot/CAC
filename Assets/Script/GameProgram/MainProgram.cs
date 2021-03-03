using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainProgram : MonoBehaviour
{
    public static MainProgram Instance;
    private PlayerManager _playerManager;


    private void Awake()
    {
        //游戏初始化时 保存游戏对象
        Instance = this;
        // 添加玩家、卡组
        gameObject.AddComponent<PlayerManager>();
        gameObject.AddComponent<DeckGroup>();
    }

    private void Start()
    {
    }

    public void GameStart()
    {
        GetComponent<TurnManager>().TurnStart();
    }


    //抽牌
    public void CardDraw(Player player)
    {
        //当前玩家抽卡
        player.CardDraw();
        // 回合开始 抽卡
        Card[] components = GetComponents<Card>();
        foreach (var t in components) t.OnTurnStart();
        foreach (var t in components) t.OnCardDraw();
    }

    private delegate Action MethodDelegate(Card card);

    // 角色执行战斗
    public void PreBattle(Character attacker)
    {
        var battleManager = gameObject.AddComponent<BattleManager>();
        battleManager.PreBattle(attacker);
    }

    // 取消战斗
    public void CancelBattle()
    {
        var battleManager = gameObject.GetComponent<BattleManager>();
        battleManager.Cancel();
        Destroy(battleManager);
    }

    //进行战斗
    public void BattleAction(Character target)
    {
        var battleManager = gameObject.GetComponent<BattleManager>();
        if (battleManager == null) return;
        battleManager.Battle(target);
    }


    // 玩家失败退场
    public void Defeated(Player player)
    {
    }

    //卡片发动
    public void Launch(Card card)
    {
    }


    //TODO 卡片破坏
    public void Break(Card card)
    {
        var score = 0;
        switch (card)
        {
            case Character c:
                score = c.Info.Score;
                break;
            case Golem g:
                score = g.Info.Score;
                break;
        }
        GetComponent<PlayerManager>().FindUnitHolder(card).SettlementDamagePoint(card, score);
        Destroy(card);
    }
}