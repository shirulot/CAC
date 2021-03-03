using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//场地 用于计算角色行动等
public class Field : MonoBehaviour
{
    [SerializeField]
    public Tile[][] tiles ;
    
    //TODO 获取当前unit所在的位置
    public int[] FindUnitLocation(Unit unit)
    {
        // foreach (var tile in tiles)
        // {
        //     
        // }

        return new[] {0, 1};
    }

    // 获取某个单位所属者(玩家)下的所有角色
    public Character[] GetCharacters(Unit unit)
    {
        var playerManager = GetComponent<PlayerManager>();
        Player holder = playerManager.FindUnitHolder(unit);
        return playerManager.GetPlayerHolderCharacters(holder.Order);
    }
}