using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // 攻击前->被攻击前-> 战斗结算 ->攻击后->被攻击后->反击前->反击后
    public void Battle(Character attacker, Character target)
    {
        attacker.OnAttackStart(target);
        target.OnBeforeBeingAttacked(attacker);
        // 双方在攻击前未被破坏才进行正式战斗结算
        if (!attacker.IsBlank && !target.IsBlank)
        {
            CombatSettlement(attacker, target);
            // 攻击后/被攻击后 即使破坏也回调 需要判断破坏的回调在方法内部进行 
            attacker.OnAttackEnd(target);
            target.OnAfterBeingAttacked(attacker);
        }

        _counterAttack(attacker, target);
    }


    private void _counterAttack(Character attacker, Character counterAttackCharacter)
    {
        if (counterAttackCharacter.CanCounterAttack() && !attacker.State.IsBreak &&
            !counterAttackCharacter.State.IsBreak)
        {
            counterAttackCharacter.OnBeforeCounterattack(attacker);
            //反击结算
            CombatSettlement(counterAttackCharacter, attacker);
            counterAttackCharacter.OnAfterCounterattack(attacker);
        }

        ComboHit(attacker, counterAttackCharacter);
    }

    private void ComboHit(Character attacker, Character targetCharacter)
    {
        bool wantCombo = true;
        while (attacker.State.Attack > 0 && wantCombo)
        {
            if (PlayerManager.GetInstance().GetCurrentActivePlayer() == attacker.Player)
            {
                // TODO 弹出弹窗 询问是否需要连击
                // 想要连击
                if (wantCombo)
                {
                    attacker.OnBeforeComboHit(targetCharacter);
                    //连击
                    CombatSettlement(attacker, targetCharacter);
                    attacker.OnAfterComboHit(targetCharacter);
                    if (targetCharacter.State.SuperCounter)
                    {
                        targetCharacter.OnBeforeCounterattack(attacker);
                        CombatSettlement(targetCharacter, attacker);
                        //超反击
                        attacker.Damage(targetCharacter.State.Attack, targetCharacter.IsPiercing());
                        targetCharacter.OnBeforeCounterattack(attacker);
                    }
                }
            }
        }

        CheckScore(targetCharacter, attacker);
    }

    private void CheckScore(Character target, Character attacker)
    {
        if (target.State.IsBreak) attacker.Player.ScoreChange(target.State.Score);
    }

    private void CombatSettlement(Character attacker, Character target)
    {
        // 命中结算
        var attackerHitRate = attacker.State.HitRate - attacker.State.Avoid;
        // 是否命中
        if (attackerHitRate > 0 && attackerHitRate > Random.Range(0, 100))
        {
            attacker.AttackTarget(target);
        }
        else
        {
            AttackMiss(attacker, target);
        }
    }

    // 攻击失误
    private void AttackMiss(Character attacker, Character target)
    {
        // 回合开始 抽卡
        // Card[] components = GetComponents<Card>();
        // foreach (var t in components) t.OnAttackMiss();

        attacker.OnAttackMiss();
    }
}