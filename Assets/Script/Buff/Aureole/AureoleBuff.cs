//光环专属子buff 一般情况下不受驱散等效果影响

public class AureoleBuff : Buff
{
    protected Aureole parent;

    public void Attach(Aureole parent, Character attachTarget)
    {
        this.attachTarget = attachTarget;
        this.parent = parent;
    }

    public override BuffType buffType()
    {
        return BuffType.Aureole;
    }

    // 光环buff基本靠特殊方式进行是否可用检查  比如移动后是否在某个范围内等
    public virtual bool EnableCheck() => true;

    // 接上个方法 故而 变更可用转态项置空
    public override void setEnable(bool enable)
    {
    }

    public override void BuffDown(int downLevel = 1)
    {
        // base.BuffDown(downLevel);
    }

    public override void BuffUp(int level = 1)
    {
        // base.BuffUp(buff);
    }
}