using System;
using System.Collections.Generic;

public class WhiteBreadKing : Leader
{
    public override string Name() => "Shiro Danko King";

    public override string Description() => "";

    private void Start()
    {
        var currentPlayer = GetComponent<PlayerManager>().GetCurrentPlayer();
        //Leader阶级统一为00
        CardInfo.Init("0001","0001",0,0);
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 7, maxHp: currentPlayer.Score, hp: currentPlayer.Score);
    }


    public override void AttachLeaderEffect()
    {
        
    }
}