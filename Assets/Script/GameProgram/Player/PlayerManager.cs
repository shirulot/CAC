using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    public List<Player> PlayerList;
    public int CurrentIndex;
    public int ActiveIndex;

    private void Awake()
    {
        PlayerList = new List<Player>();
        _playerListInit();
    }

    private void Start()
    {
        foreach (var t in PlayerList) t.InitDeck();
    }

    //切洗玩家顺序
    private void _playerListInit()
    {
        var players = GetComponents<Player>().ToList();
        var count = players.Count;
        //玩家顺序从P1开始
        ActiveIndex = 0;
        //如果是网络版 此步需要交给服务端
        CurrentIndex = Random.Range(0, count);
        for (var i = 0; i < count; i++)
        {
            var index = Random.Range(0, players.Count);
            var player = players[index];
            player.Order = i;
            players.RemoveAt(index);
            PlayerList.Add(player);
        }
    }

    public Player GetCurrentPlayer() => PlayerList[CurrentIndex];
    public Player GetActivePlayer() => PlayerList[ActiveIndex];

    public bool TurnEnd()
    {
        foreach (var player in PlayerList) player.OnTurnEnd();
        //是否是最后一个玩家
        return ActiveIndex == PlayerList.Count - 1;
    }

    //TODO 查询卡片是否为当前玩家
    public bool CardIsCurrentPlayerProperty(Card attacker)
    {
        return false;
    }

    //TODO 未实现
    public Player FindUnitHolder(Unit unit)
    {
        return GetCurrentPlayer();
    }
    //获取特定玩家的所有卡牌单元
    public Character[] GetPlayerHolderCharacters(int order)=> PlayerList[order].GetCharacters();
    
    //当前活动的玩家是否为我方
    public bool ActivePlayerIsCurrent() => ActiveIndex == CurrentIndex;
}