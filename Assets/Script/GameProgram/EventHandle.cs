using UnityEngine;


public class EventHandle : MonoBehaviour
{
    //需要去对象的效果发动时穿件
    private EffectProcessor _targetChooser;


    //@Param promoter 效果发动者
    //@Param min      最小指定数量
    //@Param max      最大指定数量
    //
    public void SelectionTarget(ITargetChooser promoter, int min, int max)
    {
        _targetChooser = new EffectProcessor(max, min, promoter);
    }

    public void Cancel()
    {
        _targetChooser = null;
    }

    public bool OnMouseDown(Card card)
    {
        _targetChooser?.Selection(card);
        return _targetChooser != null;
    }
    
    
}