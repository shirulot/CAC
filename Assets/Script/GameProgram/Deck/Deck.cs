using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    [SerializeField] public Player _player;
    private List<Card> _list = new List<Card>();

    private void Awake()
    {
        InitDeck();
    }

    // 初始化玩家卡组
    private void InitDeck()
    {
        // 卡组集
        var deckGroup = GetComponent<DeckGroup>();
        //获取当前被选中的卡组
        Card[] tempDeckList = { };
        deckGroup.CurrentDeck.GetDeckAllCard().CopyTo(tempDeckList);
        _list.AddRange(tempDeckList);
        Shuffle();
    }

    // 洗牌
    // 简易的洗牌算法 在0.._list.Count之间生成一个随机数 index
    // 然后取出_list[index] 放入newList 并且删除原数组的该下标元素
    // 直至数组count为0 而后讲newList的数据填充回_list
    // 可以照顾到每一张卡 但是大概不为最优解 存在优化控件
    public void Shuffle()
    {
        var newList = new List<Card>();
        while (_list.Count > 0)
        {
            var index = Random.Range(0, _list.Count);
            newList.Add(_list[index]);
            _list.RemoveAt(index);
        }

        _list.AddRange(newList);
    }


    // 抽牌
    public void CardDraw(Hand hand)
    {
        if (_list.Count > 0)
        {
            var drawTarget = _list[_list.Count - 1];
            hand.CardDraw(drawTarget);
            ExtraActionProgram.GetInstance().Save(ExtraTag.DrawCard, drawTarget);
        }
        else
        {
            //TODO defeated 
            MainProgram.Instance.Defeated(_player);
        }
    }

    // 根据卡片活动id(编号/No.)
    public Card FindCardByActiveId(int activeId)
    {
        for (var i = 0; i < _list.Count; i++)
        {
            var card = _list[i];
            if (card.CardInfo.activeId == activeId) return card;
        }

        return null;
    }

    public List<Card> GetDeckAllCard() => _list;

    // 寄存卡片回收
    public void DepositRecycle(List<Card> depositList)
    {
        _list.AddRange(depositList);
        Shuffle();
    }
}