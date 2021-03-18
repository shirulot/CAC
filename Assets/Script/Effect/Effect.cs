using System;
using System.Collections.Generic;

public abstract class Effect : Unit
{
    public int Level = 1;

    public bool enable = true;

    //是否可以主动使用
    public bool initiativeEnable = true;
    public abstract string Name();
    public abstract string Description();

    public Character AttachTarget;

    public virtual int Increment() => 0;

    private void Awake()
    {
        OnAttach();
    }


    public virtual void OnAttach()
    {
        AttachTarget = gameObject.GetComponentInChildren<Character>();
    }
}