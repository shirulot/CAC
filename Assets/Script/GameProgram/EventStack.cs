using System;
using System.Collections.Generic;
using UnityEngine;

public class EventStack : MonoBehaviour
{
    private List<EventMessage> list = new List<EventMessage>();
    bool waitingEvent = false;

    private void Awake()
    {
    }

    private void Update()
    {
        if (!waitingEvent)
        {
            handledEvent();
        }
    }

    private void handledEvent()
    {
        waitingEvent = true;
        if (list.Count > 0) list[list.Count].onEvent();
        waitingEvent = false;
    }

    public void EventPost(EventMessage message)
    {
        if (list.Count > 0)
            list.Insert(0, message);
        else
            list.Add(message);
    }
}

public class EventMessage
{
    //发起者
    private Player launcer = null;

    //目标玩家
    private List<Player> targets = null;

    //目标单位
    private List<Unit> units = null;

    //事件
    Func<Player, List<Player>, List<Unit>, int> mEvent;

    //执行事件
    public void onEvent()
    {
        // mEvent();
    }
}