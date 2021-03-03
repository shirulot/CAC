using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RankUpInstruction : Magic
{
    public override MagicType GetMagicType() => MagicType.InstantMagic;

    public override bool IsSingle() => true;

    public RankUpInstruction()
    {
        CardInfo.Init(seriesId: "9999", groupId: "0001", rank: 2, no: 2);
    }


    // 选择需要进行的对象
    public override void EffectPreAction()
    {
        GetComponent<EventHandle>().SelectionTarget(this,1,1);
    }

    //选中后的逻辑
    public override void TargetsSelection(List<Card> targets)
    {
        // var component = target.GetComponent<Card>();
        if (targets != null && targets.Count > 0)
        {
            var cardInfoActiveId = targets[0].CardInfo.activeId + 10;
            var currentPlayer = GetComponent<PlayerManager>().GetCurrentPlayer();
            var deck = currentPlayer.Deck;
            var hand = currentPlayer.Hand;
            var card = deck.FindCardByActiveId(cardInfoActiveId);
            hand.AddHand(card);
        }
    }

    public override string Name() => "提升指令";

    public override string Description() => "cost:10\n选定场地内的一个我方单位,将其高一阶的卡牌加入手牌";
    
}