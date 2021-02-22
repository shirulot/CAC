using System;
using System.Collections.Generic;

// 光环效果 一般为魔像衍生
public class Aureole : Lifecycle
{
    //用来存放对应
    public Dictionary<Character, Buff> AureoleMap = new Dictionary<Character, Buff>();

    private bool enable;

    public Player player;

    //光环子效果,子buff
    // public abstract AureoleBuff child();

    public void setEnabled(bool enable, Player player)
    {
        this.player = player;
        this.enable = enable;
        if (enable)
        {
            OnEnable();
        }
        else
        {
            OnDisable();
        }
    }

    //光环名称
    public virtual String Name() => "";

    //光环说明
    public virtual String Description() => "";

    public virtual void OnEnable()
    {
    }

    public virtual void OnDisable()
    {
    }
}