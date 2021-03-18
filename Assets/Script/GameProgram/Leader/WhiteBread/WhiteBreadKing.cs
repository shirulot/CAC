using System;
using System.Collections.Generic;

public class WhiteBreadKing : Leader
{
    public override string Name() => "白团子国王";

    public override string Description() => "";

    private void Start()
    {
        var currentPlayer = GetComponent<PlayerManager>().GetCurrentPlayer();
        //Leader阶级统一为00
        CardInfo.Init("0001", "0001");
        Info.Init(avoid: 5, hitRate: 95, mobility: 3, attack: 70, hp: currentPlayer.Score);
    }

    // 附加
    public override void AttachLeaderEffect()
    {
        gameObject.AddComponent<AggregatorEffect>().Init("白团子", "0001");
        gameObject.AddComponent<Recyclers>();
        gameObject.AddComponent<SPLifeRestoreEffect>();
    }

    //删除
    public override void DetachLeaderEffect()
    {
        Destroy(gameObject.GetComponent<AggregatorEffect>());
        Destroy(gameObject.GetComponent<Recyclers>());
        Destroy(gameObject.GetComponent<SPLifeRestoreEffect>());
    }

    // 附加
    public override void AttachUnitEffect()
    {
        gameObject.AddComponent<SPAegis>();
        gameObject.AddComponent<SPSpecialChargeEffect>();
        // gameObject.AddComponent<>();
    }

    // 删除
    public override void DetachUnitEffect()
    {
        Destroy(gameObject.GetComponent<SPAegis>());
        Destroy(gameObject.GetComponent<SPSpecialChargeEffect>());
    }
}