using System;
using UnityEngine;

//
public class UnitedWeStandChildBuff : AureoleBuff<UnitedWeStandChildBuff>
{


    public override string Description() => "根据场地上我方角色数量上升";

    public override string Name() => $"团结之力({_GetNameLevel()})";


    private int _attackIncremental = 0;
    private int _aegisIncremental = 0;


    //buff附加
    public override void BuffAttach()
    {
        EffectCheck(true);
    }

    // buff效果发动
    public void EffectCheck(bool isAttach = false)
    {
        //高于2级时倍率切换为1 否则为0.5倍
        float ratio = aureoleLevel <= 2 ? 0.5f : 1;

        var characters = Field.GetInstance().GetCharacters(attachTarget.Player);
        var newIncremental = Mathf.CeilToInt(characters.Count * ratio);
        var changeAttackIncremental = newIncremental - _attackIncremental;
        var changeAegisIncremental = newIncremental - _aegisIncremental;

        attachTarget.ChangeAttack(changeAttackIncremental);
        _attackIncremental = newIncremental;

        if (aureoleLevel >= 2)
        {
            attachTarget.ChangeAttack(changeAttackIncremental);
            if (isAttach && changeAegisIncremental > 0)
                attachTarget.ChangeAttack(changeAttackIncremental);

            else if (changeAttackIncremental < 0)
                attachTarget.ChangeAttack(Mathf.Abs(changeAttackIncremental));
            _attackIncremental = newIncremental;
        }
    }

    //buff去除事件
    public override void OnBuffDetach()
    {
        attachTarget = null;
    }

    // 角色入场
    public override void OnCharacterDeath()
    {
        EffectCheck();
    }


    //角色退场
    public override void OnCardBreak(Card card)
    {
        EffectCheck();
    }

    //名称后缀的 (大、中、小)
    private String _GetNameLevel()
    {
        switch (aureoleLevel)
        {
            case 3:
                return "大";
            case 2:
                return "中";
            default:
                return "小";
        }
    }
}