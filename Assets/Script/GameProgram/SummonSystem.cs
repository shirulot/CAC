using System;
using UnityEngine;

public class SummonSystem : MonoBehaviour
{
    public T CharacterSummon<T>(GameObject prefab,Vector3 position ,Golem parent = null) where T : Character
    {
        //TODO 具体位置需要选择
        GameObject obj = Instantiate(prefab, position,Quaternion.identity,prefab.transform);
        
        return obj.AddComponent<T>();
    }
}