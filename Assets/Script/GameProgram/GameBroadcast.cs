using System;
using UnityEngine;

public class GameBroadcast : MonoBehaviour
{
    
    
    public void PostLifecycle(Magic magic,Action<Unit> action)
    {
        action.Invoke(magic);
        var childrenComponents = this.GetComponentsInChildren<Unit>();
        foreach (var child in childrenComponents) action.Invoke(child);
        // effectList.ForEach(action.Invoke);
        // buffList.ForEach(action.Invoke);
    }

    
}