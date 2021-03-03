using System.Collections.Generic;

public class EffectProcessor
{
    private int _max;
    private int _min;
    private ITargetChooser _chooser;
    private bool _singleOption;
    private List<Card> _targets;

    public EffectProcessor(int max, int min, ITargetChooser chooser)
    {
        this._max = max;
        this._min = min;
        this._chooser = chooser;
        this._targets = new List<Card>();
    }

    //返回是否已经可以点击确定
    public bool Selection(Card card)
    {
        _targets.Add(card);
        return CheckCanSubmit();
    }

    private bool CheckCanSubmit()
    {
        var targetsCount = _targets.Count;

        if (_singleOption&& targetsCount == _min)
        {
            InvokeEffect();
        }
        

        return _min < targetsCount && targetsCount < _max;
    }

    private void InvokeEffect()
    {
        _chooser.EffectInvoke(_targets);
    }

    public bool Cancel(Card card)
    {
        return CheckCanSubmit();
    }
}