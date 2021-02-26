using System;
using System.Collections;
using System.Collections.Generic;


public enum BuffType
{
    DeBuff,
    Gain,
    Aureole,
    Rules
}

public class Buff : Unit
{
    // buff等级
    public int buffLevel = 0;

    //当前buff是否可用
    public bool enable = true;

    // buff剩余回合数
    int turn;

    //常驻攻击力增幅 攻击前计算
    int attackPermanentAbility;


    // 角色
    public Character attachTarget;

    public virtual void Attach(Character attachTarget)
    {
        this.attachTarget = attachTarget;
    }

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


    public virtual String Description()
    {
        return "";
    }

    public virtual String Name()
    {
        return "";
    }


    // buff等级下降 如果降到0 失去buff
    public virtual void BuffDown(int downLevel = 1)
    {
        buffLevel -= downLevel;
        if (buffLevel <= 0)
        {
            attachTarget.BuffDetach(GetType());
        }
    }
}