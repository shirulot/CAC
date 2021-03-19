using UnityEngine;

public class DiseaseTyrant<T> : Effect where T : Buff, IDisease
{
    private string _diseaseName;
    public override string Name() => $"疫病暴君<{_diseaseName}>";

    public override string Description() => $"[固有]:当前单位战斗时,战斗对象携带「{_diseaseName}」的场合,根据以下条件发动效果" +
                                            $"当前单位被攻击时,在战斗结束前下降战斗对象20攻击力。" +
                                            $"当前单位攻击时,在战斗结束前上身我方20攻击力。" +
                                            $"当前单位战斗破坏敌方单位后 永久提升10点攻击力,回复20HP";

    public void Init(string diseaseName)
    {
        _diseaseName = diseaseName;
    }

    private int _attackerIncrement = 0;
    private int _victimIncrement = 0;

    public override void OnAttackStart(Card targetCard)
    {
        if (!(targetCard is Character target) || !target.gameObject.TryGetComponent<T>(out var comp)) return;
        gameObject.GetComponent<Character>().ChangeAttack(20);
        _attackerIncrement += 20;
    }

    public override void OnAttackEnd(Card targetCharacter)
    {
        gameObject.GetComponent<Character>().ChangeAttack(-_attackerIncrement, true);
        _attackerIncrement = 0;
    }

    public override void OnBeforeBeingAttacked(Character attacker)
    {
        if (!attacker.gameObject.TryGetComponent<T>(out var comp)) return;
        attacker.ChangeAttack(-20);
        _victimIncrement -= 20;
    }

    public override void OnAfterBeingAttacked(Character character)
    {
        character.GetComponent<Character>().ChangeAttack(-_victimIncrement, true);
        _victimIncrement = 0;
    }

    public override void OnCardBreak(Card card, Unit breaker)
    {
        if (!(breaker is Character chara) || !chara.Equals(gameObject.GetComponent<Character>())) return;
        chara.ChangeAttack(10);
        chara.ChangeHp(20);
    }
}