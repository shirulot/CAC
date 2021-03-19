public class DeathDisease : Buff, IDisease
{
    private int _baseDamage = 2;
    private int _growthDamage = 1;

    public override string Name() => "死疫";

    public override string Description() => $"[异常]回合结束时给予角色{_baseDamage}点伤害。" +
                                            $"\n[固有]角色被其他角色战斗破坏时,给予其角色附加[死疫]";

   

    public override void OnTurnStart()
    {
        if (enable) attachTarget.Damage(_baseDamage + _growthDamage * buffLevel,this);
    }

    public override void OnCardBreak(Card card, Unit breaker)
    {
        if (breaker is Character chara)
        {
            chara.gameObject.AddComponent<DeathDisease>();
        }
    }
}