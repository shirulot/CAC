/// <summary>
/// 普通 时点能力 
/// </summary>
public class BerserkerForce : Gain
{
    public BerserkerForce(Character attachTarget) : base(attachTarget)
    {
    }

    // 加倍系数 
    private float _baseRatio = 2.0f;
    private int _incremental = 0;

    public override string Description() => $"进攻时获得{_baseRatio}倍攻击力,攻击后承受因这个能力上升部分的伤害";

    public override string Name() => "狂战士之力";

    public override void OnAttackStart(Character targetCharacter)
    {
        if (enable)
        {
            _incremental = attachTarget.State.Attack;
            attachTarget.ChangeAttack(_incremental);
        }
    }

    public override void OnAttackEnd(Character targetCharacter)
    {
        attachTarget.Damage(_incremental);
        attachTarget.ChangeAttack(-_incremental);
        _incremental = 0;
    }
}