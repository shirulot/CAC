using System;
using System.Collections.Generic;
using UnityEngine;

//卡组选择
public class DeckGroup : MonoBehaviour
{
    
    private List<Deck> _deckList;
    public Deck CurrentDeck;

   
    private void Awake()
    {
        InitPlayerDeckList();
        InitCurrentDeck();
    }

    //T DO 初始化玩家卡组列表 本地版根据本地缓存 
    private void InitPlayerDeckList()
    {
        
    }
    
    //t do 初始化当前已选中卡组 伪代码
    private void InitCurrentDeck()
    {
        CurrentDeck = new Deck();
    }
    
}