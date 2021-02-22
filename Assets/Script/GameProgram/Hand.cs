using System.Collections.Generic;

public class Hand
{
    private List<Card> _list = new List<Card>();

    public void CardDraw(Card card)
    {
        _list.Add(card);
    }

    public void DepositGetBack(List<Card> depositList)
    {
        _list.AddRange(depositList);
    }
}