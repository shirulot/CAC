using UnityEngine;
using UnityEngine;
using UnityEngine.UIElements;

//菜单栏回合结束点击
public class MenuAttack : MonoBehaviour
{
    // 回合结束。轮换
    private void _attack()
    {
        MainProgram.Instance.TakeTurns();
    }
}