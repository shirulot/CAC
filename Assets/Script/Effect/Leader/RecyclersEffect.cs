using System.Collections.Generic;

public class Recyclers : Effect
{
    public override string Name() => "回收者";

    public override string Description() => $"单位被回收时,增加{Increment()}积分";

    private int _base = 4;
    private int _increment = 1;

    public override int Increment() => _base + _increment * (Level - 1);
    
    public void Init(int level = 1)
    {
        this.Level = level;
    }

    public override void OnCardRecycle(List<Card> depositList)
    {
        gameObject.GetComponent<Leader>().ChangePoint(Increment() * depositList.Count);
    }
}