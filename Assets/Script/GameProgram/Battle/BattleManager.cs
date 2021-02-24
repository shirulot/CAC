using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private Character _attacker;

    // 用户点击角色攻击button后存放当前角色
    public void PreBattle(Character attacker)
    {
        this._attacker = attacker;
    }

    // 取消战斗
    public void Cancel()
    {
        this._attacker = null;
    }

    // 攻击前->被攻击前-> 战斗结算 ->攻击后->被攻击后->反击前->反击后
    public void Battle(Character target)
    {
        _attacker.OnAttackStart(target);
        target.OnBeforeBeingAttacked(_attacker);
        // 双方在攻击前未被破坏才进行正式战斗结算
        if (!_attacker.IsBlank && !target.IsBlank)
        {
            CombatSettlement(_attacker, target);
            // 攻击后/被攻击后 即使破坏也回调 需要判断破坏的回调在方法内部进行 
            _attacker.OnAttackEnd(target);
            target.OnAfterBeingAttacked(_attacker);
        }

        _counterAttack(target);
    }

    // 反击
    private void _counterAttack(Character counterAttackCharacter)
    {
        if (counterAttackCharacter.CanCounterAttack() && !_attacker.State.IsBreak &&
            !counterAttackCharacter.State.IsBreak)
        {
            counterAttackCharacter.OnBeforeCounterattack(_attacker);
            //反击结算
            CombatSettlement(counterAttackCharacter, _attacker);
            counterAttackCharacter.OnAfterCounterattack(_attacker);
        }

        ComboHit(counterAttackCharacter);
    }

    // 连击
    private void ComboHit(Character targetCharacter)
    {
        bool wantCombo = true;
        while (_attacker.State.Attack > 0 && wantCombo)
        {
            if (GetComponent<PlayerManager>().GetCurrentActivePlayer() == _attacker.Player)
            {
                // TODO 弹出弹窗 询问是否需要连击
                // 想要连击
                if (wantCombo)
                {
                    _attacker.OnBeforeComboHit(targetCharacter);
                    //连击
                    CombatSettlement(_attacker, targetCharacter);
                    _attacker.OnAfterComboHit(targetCharacter);
                    if (targetCharacter.State.SuperCounter)
                    {
                        targetCharacter.OnBeforeCounterattack(_attacker);
                        CombatSettlement(targetCharacter, _attacker);
                        //超反击
                        _attacker.Damage(targetCharacter.State.Attack, targetCharacter.IsPiercing());
                        targetCharacter.OnBeforeCounterattack(_attacker);
                    }
                }
            }
        }

        CheckScore(targetCharacter);
    }

    // 检查破坏 并结算分数
    private void CheckScore(Character target)
    {
        if (target.State.IsBreak) _attacker.Player.ScoreChange(target.State.Score);
    }

    //战斗结算
    private void CombatSettlement(Character attacker, Character target)
    {
        // 命中结算
        var attackerHitRate = attacker.State.HitRate - attacker.State.Avoid;
        // 是否命中
        if (attackerHitRate > 0 && attackerHitRate > Random.Range(0, 100))
        {
            _attacker.AttackTarget(target);
        }
        else
        {
            //攻击/反击 失误
            AttackMiss(attacker, target);
        }
    }

    // 攻击失误
    private void AttackMiss(Character attacker, Character target)
    {
        attacker.OnAttackMiss();
        target.OnAvoidAttack();
    }
}