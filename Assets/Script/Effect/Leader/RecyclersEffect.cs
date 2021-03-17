using System.Collections.Generic;

public class Recyclers : Effect
{
    public override string Name() => "回收者";

    public override string Description() => $"单位被回收时,增加{_basePoint + _increment}积分";

    private int _basePoint = 5;
    private int _increment = 0;

    public override void OnCardRecycle(List<Card> depositList)
    {
        var pointIncrement = _basePoint + _increment;
        gameObject.GetComponent<Leader>().ChangePoint(pointIncrement * depositList.Count);
    }
}