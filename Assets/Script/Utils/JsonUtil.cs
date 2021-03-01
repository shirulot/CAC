using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonUtil : MonoBehaviour
{

    //TODO 伪代码
    public static T ToJson<T>(T obj)
    {
        return obj;
        //
        // JsonSerializer serializer;
        // var textWriter  = TextWriter("//");
        // var a =  JsonSerializer.Serialize(,obj);
    }

    //TODO 伪代码
    public static Deck GetCurrentDeck()
    {
        return ToJson(new Deck());
    }

    // TODO 伪代码
    public static List<Deck> GetDeckList()
    {
        return ToJson(new List<Deck>());
    }
}