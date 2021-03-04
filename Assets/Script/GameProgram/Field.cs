using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//场地 用于计算角色行动等
public class Field : MonoBehaviour
{
    [SerializeField] public Tile[][] tiles;

    //TODO 获取当前unit所在的位置
    public Vector2 FindUnitLocation(Unit unit)
    {
        // foreach (var tile in tiles)
        // {
        //     
        // }

        return new Vector2(0, 1);
    }

    // 获取某个单位所属者(玩家)下的所有角色
    public Character[] GetCharacters(Unit unit)
    {
        var playerManager = GetComponent<PlayerManager>();
        Player holder = playerManager.FindUnitHolder(unit);
        return playerManager.GetPlayerHolderCharacters(holder.Order);
    }

    public List<Character> FindLineUnit(Unit unit)
    {
        var location = FindUnitLocation(unit);
        var orientation = GetComponent<PlayerManager>().FindUnitHolder(unit).FindOrientation();


        Tile tile;
        var list = new List<Character>();
        do
        {
            location += orientation;
            tile = GetTile(location);
            var character = tile.gameObject.GetComponent<Character>();
            if (character != null) list.Add(character);
        } while (tile != null);

        return list;
    }

    //通过向量获取tile(地板)
    private Tile GetTile(Vector2 location)
    {
        if (location.x > 7 || location.x < 0  || location.y > 7|| location.x<0)
        {
            return null;
        }

        return ScriptableObject.CreateInstance<Tile>();
    }
}