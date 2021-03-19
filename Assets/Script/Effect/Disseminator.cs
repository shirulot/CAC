using UnityEngine;

public class Disseminator<T> : Buff, IDisease where T : Buff, IDisease
{
    private string _diseaseName = "";
    public override string Name() => $"{_diseaseName}传播者";

    public override string Description() => $"给予战斗对象的角色附加[{_diseaseName}]";

    public void Init(string diseaseName )
    {
        this._diseaseName = diseaseName;
    }
    
    public override void OnAttackStart(Card targetCard)
    {
        //单位为角色 并且非死疫携带者时 附加死疫
        if (targetCard is Character target && !target.Info.IsBreak && target.gameObject.GetComponent<T>() == null)
        {
            target.gameObject.AddComponent<T>();
        }
    }


    public override void OnBeforeBeingAttacked(Character attacker)
    {
        var attackerGameObject = attacker.gameObject;
        if (attackerGameObject.GetComponent<T>() == null)
        {
            attackerGameObject.AddComponent<T>();
        }
    }
}