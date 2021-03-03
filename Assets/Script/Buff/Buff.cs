using System;
using System.Collections;
using System.Collections.Generic;


public enum BuffType
{
    //减益效果
    DeBuff,

    //增益效果
    Gain,

    //光环效果
    Aureole,

    //说明性 规则buff
    Rules
}

public class Buff : Unit
{
    // buff等级
    public int buffLevel = 0;

    //当前buff是否可用
    public bool enable = true;

    // buff经过回合数
    public int PassedTurns = 0;

    // 持续性buff 总回合数
    public int TotalTurns = 99;

    // 角色
    public Character attachTarget;

    

    //buff类型
    public virtual BuffType buffType()
    {
        return BuffType.Gain;
    }

    // 获得buff时触发
    public virtual void BuffAttach()
    {
    }

    // buff等级提升
    public virtual void BuffUp(int level)
    {
        BeforeBuffUp(level);
        buffLevel += level;
        AfterBuffUp(level);
    }

    // buff等级提升前事件
    public virtual void BeforeBuffUp(int level)
    {
    }

    // buff等级提升后事件
    public virtual void AfterBuffUp(int level)
    {
    }

    // 失去buff 
    public virtual void OnBuffDetach()
    {
        attachTarget = null;
    }

    // 强制触发时的处理
    public virtual void ForceTrig()
    {
    }

    public virtual void setEnable(bool enable)
    {
        this.enable = enable;
        OnEnableChange();
    }

    public virtual void OnEnableChange()
    {
    }

    public override void OnTurnEnd()
    {
        PassedTurns++;
        base.OnTurnEnd();
    }


    // buff等级下降 如果降到0 失去buff
    public virtual void BuffDown(int downLevel = 1)
    {
        buffLevel -= downLevel;
        if (buffLevel <= 0) attachTarget.BuffDetach(GetType());
    }
}