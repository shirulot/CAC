using System;
using UnityEngine;

// using UnityEngine.EventSystems;
// using UnityEngine.UI;
// using UnityEditor;


public class RankUpInstruction : Magic
{
    private void Start()
    {
        _component = target.GetComponent<Character>();
    }

    private void Awake()
    {
        _component = target.GetComponent<Character>();
    }

    public override MagicType GetMagicType() => MagicType.InstantMagic;

    public override void OnUseEffect()
    {
        // var mouseButtonDown = Input.GetMouseButtonDown(0);
    }

    GameObject target = new GameObject();
    private Character _component;


    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        // EventSystem.current.IsPointerOverGameObject();
        // GameObject target = new GameObject();
        if (target.GetType().IsInstanceOfType(typeof(Character)))
        {
            var cardInfoActiveId = _component.CardInfo.activeId + 10;
        }
    }
}