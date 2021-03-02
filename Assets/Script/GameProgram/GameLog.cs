using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameLog :MonoBehaviour
{
    private Dictionary<String, LogEvent> dictionary = new Dictionary<String, LogEvent>();
    
    //TODO 获取玩家待实现 
    public void Save(string eventName, Object obj) => dictionary.Add(eventName, new LogEvent(1,GetComponent<PlayerManager>().GetCurrentPlayer(),obj));
    
}

class LogEvent
{
    private int turn;
    private Player player;
    Object obj;

    public LogEvent(int turn, Player player, Object obj)
    {
        this.turn = turn;
        this.player = player;
        this.obj = obj;
    }
}