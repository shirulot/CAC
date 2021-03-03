using System;
using UnityEngine;

public class GameBroadcast : MonoBehaviour
{
    public void PostLifecycle(Magic magic, Action<Unit> action)
    {
        action.Invoke(magic);
        var units = GetComponents<Unit>();
        foreach (var child in units) action.Invoke(child);
    }
}