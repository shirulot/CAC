using System.Collections.Generic;
using UnityEngine;

//场地
public class Field :MonoBehaviour
{
    Dictionary<Player, List<Character>> characterMap = new Dictionary<Player, List<Character>>();
    Dictionary<Player, List<Golem>> golemMap = new Dictionary<Player, List<Golem>>();
    Dictionary<Player, List<Magic>> magicMap = new Dictionary<Player, List<Magic>>();

    private static Field _instance;

    private Field()
    {
    }

    public static Field GetInstance() => _instance ?? (_instance = new Field());

    // 获取场地中指定玩家的所有角色卡
    public List<Character> GetCharacters(Player player = null)
    {
        if (player != null) return characterMap[player];

        var characters = new List<Character>();
        foreach (var keyValuePair in characterMap) characters.AddRange(keyValuePair.Value);
        return characters;
    }
}