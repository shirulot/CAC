using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 管理生命周期的最小单元
 */
public class Unit : MonoBehaviour
{
    // 卡片名字
    public virtual String Name() => "";

    // Unit 单位日志 用于记录当前是否已经作用过某种效果等
    public Dictionary<string, object> UnitLog = new Dictionary<string, object>();

    // 卡片说明
    public virtual String Description() => "";

    List<String> _timePointList = new List<String>();

    //抽卡时
    public virtual void OnCardDraw()
    {
    }

    // 攻击被回避
    public virtual void OnAttackMiss()
    {
    }

    // 成功回避攻击
    public virtual void OnAvoidAttack()
    {
    }

    //override 回合开始时点
    public virtual void OnTurnStart()
    {
    }

    //override 攻击前时点
    public virtual void OnAttackStart(Card targetCard)
    {
    }

    // 被攻击前
    public virtual void OnBeforeBeingAttacked(Character attacker)
    {
    }

    //override 攻击结束
    public virtual void OnAttackEnd(Card targetCharacter)
    {
    }

    // 被攻击后
    public virtual void OnAfterBeingAttacked(Character character)
    {
    }

    // 反击前
    public virtual void OnBeforeCounterattack(Character counterTarget)
    {
    }

    // 反击后
    public virtual void OnAfterCounterattack(Character counterTarget)
    {
    }


    // 回合结束时点
    public virtual void OnTurnEnd()
    {
    }

    // 卡片发动
    public virtual void OnCardAction()
    {
    }

    // 角色入场 【容易形成误解的命名】  
    public virtual void OnCharacterDeath(Character target)
    {
    }

    // 当前卡片破坏
    public virtual void OnBreak(Unit unit)
    {
    }

    // 卡片破坏
    public virtual void OnCardBreak(Card card, Unit breaker)
    {
    }

    // 魔像入场
    public virtual void OnGolemSummon()
    {
    }

    // 魔像破坏
    public virtual void OnGolemBreak(Card breaker, Golem golem)
    {
    }

    // 魔术被触发
    public virtual void OnMagicTrigger()
    {
    }

    // 单位HP变动时
    public virtual void OnHpChange(int incremental, Unit unit)
    {
    }

    //其他单位发动效果时
    public virtual void OnEffectLaunch(Unit unit)
    {
    }

    //当卡片被回收时
    public virtual void OnCardRecycle(List<Card> depositList)
    {
    }

    // public bool CheckTimePoint(String timePoint) => _timePointList.Contains(timePoint);
}

// public class TimePoint
// {
//     public static String OnCardDraw = "OnCardDraw";
//     public static String OnAttackMiss = "OnAttackMiss";
//     public static String OnTurnStart = "OnTurnStart";
//     public static String OnAttackStart = "OnAttackStart";
//     public static String OnBeforeBeingAttacked = "OnBeforeBeingAttacked";
//     public static String OnAfterBeingAttacked = "OnAfterBeingAttacked";
//     public static String OnBeforeCounterattack = "OnBeforeCounterattack";
//     public static String OnAfterCounterattack = "OnAfterCounterattack";
//     public static String OnAttackEnd = "OnAttackEnd";
//     public static String OnTurnEnd = "OnTurnEnd";
//     public static String OnCardAction = "OnCardAction";
//     public static String OnCharacterDeath = "OnCharacterDeath";
//     public static String OnCharacterDisappear = "OnCharacterDisappear";
//     public static String OnGolemSummon = "OnGolemSummon";
//     public static String OnGolemBreak = "OnGolemBreak";
//     public static String OnMagicTrigger = "OnMagicTrigger";
//     public static String OnAttackChange = "OnAttackChange";
// }