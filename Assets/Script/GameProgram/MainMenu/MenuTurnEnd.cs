using UnityEngine;
using UnityEngine;
using UnityEngine.UIElements;

//菜单栏回合结束点击
public class MenuTurnEnd : MonoBehaviour
{
    // 回合结束。轮换
    private void _turnEnd()
    {
        MainProgram.Instance.TakeTurns();
    }
}