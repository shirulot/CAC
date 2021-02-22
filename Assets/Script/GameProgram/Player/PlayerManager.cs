using System.Collections.Generic;
using UnityEngine;

//回合计数器 非mono类 属于CACProgram的逻辑拆分
public class PlayerManager : MonoBehaviour
{
    //玩家列表
    private Player[] _players;

    //当前是第几个玩家行动
    private int _activePlayerIndex = 0;

    // 当前玩家的下标
    private int _currentPlayerIndex = 0;

    //当前为第几回合
    public int Turn = 0;

    //当前行动玩家
    private Player _activePlayer;

    //当前玩家
    public Player CurrentPlayer;

    // 当前游戏规则主脚本
    private MainProgram _program;

    // log
    private ExtraActionProgram _extraActionProgram;

    private static PlayerManager _instance;
    public static PlayerManager GetInstance() => _instance;


    // 获取当前玩家
    public Player GetCurrentPlayer() => _players[_currentPlayerIndex];

    // 获取当前行动的玩家
    public Player GetCurrentActivePlayer() => _players[_activePlayerIndex];


    private PlayerManager()
    {
    }


    public static void Init(MainProgram program)
    {
        //单列化当前对象 并向游戏对象添加当前脚本 
        if (_instance == null) _instance = program.GameProgram.AddComponent<PlayerManager>();
        _instance._program = program;
    }

    // 玩家轮换
    public void TakePlayerTurns()
    {
        _activePlayerIndex++;
        if (_activePlayerIndex <= _players.Length)
        {
            _activePlayer = _players[_activePlayerIndex];
            //该玩家开始新回合
            _activePlayer.NewTurn();
            // 将当前行动玩家更换为当前玩家
            _extraActionProgram = ExtraActionProgram.GetInstance();
            _extraActionProgram.SavePlayer(ExtraTag.ActionTurnPlayer, _activePlayer);
            CardDraw();
        }
        else
        {
            _activePlayerIndex = 0;
            TurnChange();
        }
    }

    public void CardDraw()
    {
        //该玩家抽卡 并调用所有对象的抽卡生命周期
        _program.CardDraw(_activePlayer);
        // 抽牌动画
        _animCardDraw();
    }


    //执行抽卡动画
    private void _animCardDraw()
    {
        for (var i = 0; i < _players.Length; i++)
        {
            if (_activePlayerIndex == _currentPlayerIndex)
            {
                //TODO 当前玩家抽卡动画
            }
            else
            {
                //TODO 其他玩家抽卡动画
            }
        }
    }

    //回合轮换
    private void TurnChange()
    {
        Turn++;
        //TODO 回合轮换
        _program.TurnStart();
    }

    private void Awake()
    {
        _players = GetComponents<Player>();
        //伪代码
        _currentPlayerIndex = 0;
        _activePlayer = _players[0];
        CurrentPlayer = _players[_currentPlayerIndex];
    }

    private void Start()
    {
        foreach (var t in _players) t.InitDeck();
    }
}