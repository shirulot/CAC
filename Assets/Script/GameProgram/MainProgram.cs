using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainProgram : MonoBehaviour
{
    public static MainProgram Instance;
    private PlayerManager _playerManager;
    [SerializeField]
    public GameObject GameProgram;

    private void Awake()
    {
        //游戏初始化时 保存游戏对象
        Instance = this;
        // 保存回合计数器对象
        PlayerManager.Init(this);
        _playerManager = PlayerManager.GetInstance();
    }

    private void Start()
    {
        TakeTurns();
    }

    private void Update()
    {
        
    }

    // 回合开始
    public void TurnStart()
    {
        foreach (var t in GetComponents<Card>()) t.OnTurnStart();
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

    // 攻击前->被攻击前-> 战斗结算 ->攻击后->被攻击后->反击前->反击后
    public void Attack()
    {
        Character attacker = (Character) ExtraActionProgram.GetInstance().FindCard(ExtraTag.ActionCharacter);
        Character targetCharacter = (Character) ExtraActionProgram.GetInstance().FindCard(ExtraTag.TargetCharacter);
    }


    public void TurnEnd()
    {
    }

    public void CardAction()
    {
    }

    //角色登场
    public void CharacterDeath(Card card)
    {
    }

    public void CharacterDisappear()
    {
    }

    public void GolemSummon()
    {
    }

    public void MagicTrigger()
    {
    }

    // 回合轮换/当前玩家结束回合 
    public void TakeTurns()
    {
        //TODO 调用所有方法的OnTurnEnd 方法
        _playerManager.TakePlayerTurns();
    }

    // 玩家失败退场
    public void Defeated(Player player)
    {
    }

    //卡片发动
    public void Launch(Card card)
    {
        
    }

    
    //卡片破坏
    public void Break(Card card)
    {
        
    }
}