using System;
using System.Collections.Generic;

// 光环效果 一般为魔像衍生
public class Aureole<T> : Unit where T : Buff
{
    //用来存放对应
    // public Dictionary<Character, Buff> AureoleMap = new Dictionary<Character, Buff>();

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

    //光环效果失效时 清除buff [一回合内失效之类的效果对于光环也会进行清除]
    public virtual void OnDisable()
    {
        var children = GetComponents<T>();
        foreach (var child in children)
        {
            child.OnBuffDetach();
            Destroy(child);
        }
    }
}