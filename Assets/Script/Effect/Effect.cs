using System;
using System.Collections.Generic;

public enum EffectType
{
    initiative,
    passive,
    ask,
}

public abstract class Effect : Unit
{
    public int Level = 1;

    public bool enable = true;

    //是否可以主动使用
    public bool Initiative = false;
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

    public virtual EffectType  LaunchType()=> EffectType.passive;
}