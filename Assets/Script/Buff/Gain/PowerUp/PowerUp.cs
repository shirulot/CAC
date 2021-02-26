using System;
using UnityEngine;

/// <summary>
///  常驻能力 不会自动失效
/// </summary>
public class PowerUp : Gain
{
    //上升倍率
    private float _incremental = 1;


    public override string Name() => "力量上升";
    public override string Description() => $"上升角色攻击力 等级 * {_incremental}";


    // buff 附加
    public override void BuffAttach()
    {
        attachTarget.ChangeAttack(Mathf.CeilToInt(_incremental * buffLevel));
    }

    // buff 升级
    public override void BuffUp(int level)
    {
        buffLevel += level;
        if (enable) attachTarget.ChangeAttack(Mathf.CeilToInt(level * _incremental));
    }

    // buff 清除
    public override void OnBuffDetach()
    {
        if (enable) attachTarget.ChangeAttack(-Mathf.CeilToInt(buffLevel * _incremental));
        buffLevel = 0;
    }

    // 可用/禁用
    public override void OnEnableChange()
    {
        attachTarget.ChangeAttack(enable
            ? Mathf.CeilToInt(buffLevel * _incremental)
            : -Mathf.CeilToInt(buffLevel * _incremental));
    }

    //等级下降
    public override void BuffDown(int downLevel = 1)
    {
        if (enable) attachTarget.ChangeAttack(-Mathf.CeilToInt(downLevel * _incremental));
        base.BuffDown(downLevel);
    }
}