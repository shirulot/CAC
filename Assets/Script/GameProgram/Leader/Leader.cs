using System.Collections.Generic;

public class Leader : Unit
{
    private List<Card> _depositList;
    private int _depositCountDown = 1;
    public int maxCapacity = 2;
    public int GetBackPoint = 10;
    
    public override void OnTurnStart()
    {
        if (_depositList.Count > 0)
        {
            CheckCardRecycle();
            _depositCountDown--;
        }

        _depositCountDown = _depositCountDown < 0 ? 1 : _depositCountDown;
    }

    //检查寄存卡片是否回收
    private void CheckCardRecycle()
    {
        if (_depositCountDown >= 0) return;
        GetComponent<PlayerManager>().GetCurrentPlayer().Deck.DepositRecycle(_depositList);
    }

    //卡片寄存
    public void CardDeposit(Card card)
    {
        //TODO 是否寄存已满应该交由CACProgram判断
        if (_depositList.Count >= maxCapacity) return;
        _depositList.Add(card);
    }

    // 卡片取回
    // 只能一次性全部取回
    public void CardGetBack()
    {
        //无寄存卡
        if (_depositList.Count <= 0) return;
        var currentPlayer = GetComponent<PlayerManager>().GetCurrentPlayer();
        //点数足够取回
        if (currentPlayer.ActionPoint > _depositList.Count * GetBackPoint)
        {
            currentPlayer.Hand.DepositGetBack(_depositList);
        }
        else
        {
            //点数不够取回
            //TODO 提示当前点数不够
        }
    }
}