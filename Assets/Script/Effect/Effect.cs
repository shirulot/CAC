using System;
using System.Collections.Generic;

public class Effect : Lifecycle
{
    int level;
    public bool enable = true;
    public virtual String Name() => "";
    public virtual String Description() => "";

    protected Character attachTarget;

    // private List<String> abilityTag = new List<String> {BaseTag.Ability, BaseTag.Ability};

    public Effect(Character attachTarget)
    {
        this.attachTarget = attachTarget;
    }

    public virtual void OnAttach()
    {
    }
}