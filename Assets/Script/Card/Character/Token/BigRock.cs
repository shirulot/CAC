using System;

// 000000000001 
public class BigRock : Character
{
    public override string Name() => "巨石";
    public override string Description() => "";

    private void Awake()
    {
        CardInfo.Init("0000", "0000", 0, 0, "01");
        Info.Init(avoid: 0, hp: 70);
    }
}