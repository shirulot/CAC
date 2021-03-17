using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//卡片
public class Card : Unit, IComparable
{

    // 卡片预制体
    [SerializeField]
    public GameObject CardPrefab;
    
    // 单位预制体 (当前设想:魔术没有)
    [SerializeField]
    public GameObject UnitPrefab;


    public readonly bool IsBlank = false;


    public CardInfo CardInfo = new CardInfo();

    //单阶卡片 单阶卡片强度不依照阶级而定 单纯受卡片效果影响 强度维持在 1-2阶水准
    public virtual bool IsSingle() => true;



    // 根据游戏id排序
    public int CompareTo(object obj) => obj is Card c && c.CardInfo.activeId > CardInfo.activeId ? 1 : 0;
    
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject(-1))
        {
            // 当前点击是否被拦截 否则为普通点击
            var isIntercept = GetComponent<EventHandle>().OnClick(this);
            if (!isIntercept) OnMouseClick();
        }
        //监听右键
        else if (EventSystem.current.IsPointerOverGameObject(0))
        {
            GetComponent<EventHandle>().Cancel();
            OnCancel();
        }
    }

    private void OnCancel()
    {
        
    }
    
    public virtual void OnMouseClick()
    {
        
    }

    public virtual void EffectLaunch()
    {
        
    }
    // 当魔像充能完成时
    public virtual void OnChargeComplete(Golem golem)
    {
        
    }
    
  
}