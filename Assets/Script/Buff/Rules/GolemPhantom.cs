
// 说明性buff  实际效果已计入规则
public class GolemPhantom : Buff
{
    public override BuffType buffType() => BuffType.Rules;

    public override string Description() => "规则:无法消除" +
                                            "\n无法对当前单位造成伤害。该单位无法位于本体距离1的位置。" +
                                            "\n当回合开始时,当前单位距离本体的距离大于SoulLink数时," +
                                            "回收单位并对本体造成当前SoulLink值等额的伤害。";

    public override string Name() => "Golem Phantom";
}