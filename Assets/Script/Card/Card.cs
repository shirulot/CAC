using System;
using UnityEngine;

//卡片
public class Card : Lifecycle, IComparable
{
    protected Card()
    {
    } 

    public readonly bool IsBlank = false;


    public CardInfo CardInfo = new CardInfo();

    //单阶卡片 单阶卡片强度不依照阶级而定 单纯受卡片效果影响 强度维持在 1-2阶水准
    public virtual bool IsSingle() => true;
    
    public Card(bool isBlank)
    {
        IsBlank = isBlank;
    }

    //创建空白卡
    public static Card NewBlankCard() => new Card(true);


    // 根据游戏id排序
    public int CompareTo(object obj) => obj is Card c && c.CardInfo.activeId > CardInfo.activeId ? 1 : 0;
}