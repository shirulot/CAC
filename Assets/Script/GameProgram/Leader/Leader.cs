using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Leader : Character
{
    // 本体 预制体
    [SerializeField] private GameObject UnitPrefab;

    // 本体寄存卡槽
    private List<Card> _depositList;

    // 寄存卡消化回合
    private int _depositCountDown = 1;

    // 最大容量 默认2张
    public int maxCapacity = 2;

    // 取回需要消耗点数
    public int GetBackPoint = 10;

    // 卡片寄存系统是否可用
    public bool DepositIsBlock = false;

    // 单位能力是否可用
    public bool UnitEffectIsBlock = true;

    // 领队能力是否可用
    public bool LeaderEffectIsBlock = true;

    // 特殊指示物
    public int SPToken = 0;

    public bool IsLeader = true;

    public override void OnTurnStart()
    {
        if (_depositList.Count > 0)
        {
            CheckCardRecycle();
            _depositCountDown--;
        }

        _depositCountDown = _depositCountDown < 0 ? 1 : _depositCountDown;
    }

    //检查寄存卡片是否回收
    private void CheckCardRecycle()
    {
        if (_depositCountDown >= 0) return;
        GetComponent<PlayerManager>().GetCurrentPlayer().Deck.DepositRecycle(_depositList);
        OnCardRecycle(_depositList);
    }


    //卡片寄存
    public void CardDeposit(Card card)
    {
        if (!DepositIsBlock || !IsLeader)
        {
            //TODO 提示需要修改
            Toast.Create("寄存不可用").Show();
            return;
        }
        else if (_depositList.Count >= maxCapacity)
        {
            //TODO 是否寄存已满
            Toast.Create("寄存数量已达上限").Show();
            return;
        }

        _depositList.Add(card);
    }

    // 卡片取回
    // 只能一次性全部取回
    public void CardGetBack()
    {
        //无寄存卡
        if (_depositList.Count <= 0) return;
        var currentPlayer = GetComponent<PlayerManager>().GetCurrentPlayer();
        //点数足够取回
        if (currentPlayer.ActionPoint > _depositList.Count * GetBackPoint)
        {
            currentPlayer.Hand.DepositGetBack(_depositList);
        }
        else
        {
            //点数不够取回
            Toast.Create("当前点数不够取回").Show();
        }
    }

    //本体伤害分数进行联动
    public override void ChangeHp(int incremental, bool breakIsLock)
    {
        // base.changeHp(incremental);
        Info.Hp += incremental;
        Info.Score += incremental;
        GetComponent<GameBroadcast>()
            .PostLifecycle(magic, delegate(Unit lifecycle) { lifecycle.OnHpChange(incremental, this); });
    }

    public virtual void AttachUnitEffect()
    {
    }

    public virtual void DetachUnitEffect()
    {
    }

    public virtual void AttachLeaderEffect()
    {
    }

    public virtual void DetachLeaderEffect()
    {
    }

    //移动后 判断当前是否在领队席上 如果不是则切换为单位效果 否则切换为领队效果
    public void OnMoved()
    {
        //判断当前位置
        var location = GetComponent<Field>().FindUnitLocation(this);
        // TODO mock 判断当前是否在领队位置
        IsLeader = location[0] == 5 && location[1] == 5;
        if (IsLeader) AttachLeaderEffect();
        else AttachUnitEffect();
        if (IsLeader) DetachUnitEffect();
        else DetachLeaderEffect();
    }

    public void ChangePoint(int increment)
    {
        Info.Hp += increment;
    }

    public void ChangeSPToken(int increment)
    {
        SPToken += increment;
    }
}