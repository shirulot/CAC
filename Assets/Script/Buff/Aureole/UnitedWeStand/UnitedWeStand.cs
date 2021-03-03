using System;
using System.Collections.Generic;

//团结之力光环
public class UnitedWeStand : Aureole
{
    int aureoleLevel = 0;

    public void Attach(int aureoleLevel)
    {
        this.aureoleLevel = aureoleLevel;
    }

    public override Type GetChildBuffType() => typeof(UnitedWeStandChildBuff);

    public override string Name()
    {
        switch (aureoleLevel)
        {
            case 2:
                return "前线支援";
            case 3:
                return "团结之力";
            default:
                return "犬猿同盟";
        }
    }

    public override string Description() => $"给予我方所有友军单位赋予[团结之力({_GetNameLevel()})]";


    // 光环效果可用 如果中途失效过 会重复赋予
    public override void OnEnable()
    {
        foreach (var child in GetComponents<Character>())
        {
            var buff = child.BuffAttach<UnitedWeStandChildBuff>();
            buff.Attach(child, aureoleLevel);
        }
    }

    public void AureoleLevelChange(int level)
    {
        this.aureoleLevel += level;
        foreach (var child in GetComponents<Character>())
            child.GetComponent<UnitedWeStandChildBuff>().BuffLevelChange(level);
    }

    //名称后缀的 (大、中、小)
    public String _GetNameLevel()
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