using UnityEngine;

//TODO 待抽取
public class TurnManager : MonoBehaviour
{
    
    public int Turn = 0;
    
    // 回合开始
    public void TurnStart()
    {
        foreach (var t in GetComponents<Card>()) t.OnTurnStart();
    }

    public void TurnEnd()
    {
        foreach (var t in GetComponents<Card>()) t.OnTurnEnd();
        var isLast = GetComponent<PlayerManager>().TurnEnd();
        if (isLast) Turn++;
        TurnStart();
    }

    public void CardDraw()
    {
        //该玩家抽卡 并调用所有对象的抽卡生命周期
        foreach (var player in GetComponents<Player>())  player.OnCardDraw();
        foreach (var card in GetComponents<Card>())  card.OnCardDraw();
    }
}