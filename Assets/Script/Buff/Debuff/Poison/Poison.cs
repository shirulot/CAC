using UnityEngine;

/// <summary>
/// 中毒 普通 回合开始时根据中毒等级造成伤害
/// 造成伤寒后下降buff等级 等级为0时 自动移除
/// </summary>
public class Poison : Debuff, IPoison
{
    private float _baseDamage = 0;
    private float _growthDamage = 0.5f;

    public Poison(Character attachTarget) : base(attachTarget)
    {
    }

    public override string Description() => "回合开始时根据中毒等级造成伤害" +
                                            $"\n下次造成结算时{Mathf.CeilToInt(_baseDamage + _growthDamage * buffLevel)}伤害";

    public override string Name() => "中毒";

    // 伤害幅度为 1 1 2 2 3 3 ...
    public override void OnTurnStart()
    {
        if (enable) attachTarget.Damage(Mathf.CeilToInt(_baseDamage + _growthDamage * buffLevel));
        BuffDown();
    }
}