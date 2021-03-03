using System;
using System.Collections.Generic;

public class Effect : Unit
{
    int level;
    public bool enable = true;
    public virtual String Name() => "";
    public virtual String Description() => "";

    public Character AttachTarget;
    
    
    
    private void Awake()
    {
        OnAttach();
    }
    
    
    public virtual void OnAttach()
    {
        AttachTarget = gameObject.GetComponentInChildren<Character>();

    }
}