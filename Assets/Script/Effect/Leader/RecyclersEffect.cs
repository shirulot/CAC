using System.Collections.Generic;

public class Recyclers : Effect
{
    public override string Name() => "回收者";

    public override string Description() => $"单位被回收时,增加{_score}积分";

    private int _score = 5;

    public void Init(int score)
    {
        this._score = score;
    }

    public override void OnCardRecycle(List<Card> depositList)
    {
        gameObject.GetComponent<Leader>().ChangePoint(_score * depositList.Count);
    }
}