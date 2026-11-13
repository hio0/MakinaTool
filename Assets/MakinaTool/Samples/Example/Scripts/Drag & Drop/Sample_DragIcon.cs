using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

[RequireComponent(typeof(DragIcon))]
public class Sample_DragIcon : IdentitiyClass
{
    [Header("기능 클래스")]
    [SerializeField] DragIcon dragIcon;

    [Header("클래스 변수")]
    [SerializeField] TMP_Text text;

    void OnEnable()
    {
        dragIcon.OnInitialize += IconChange;
    }

    void OnDisable()
    {
        dragIcon.OnInitialize -= IconChange;

        dragIcon.Deactivate();
    }

    void IconChange()
    {
        if (TryGetObject<Sample_DragDropData>(dragIcon.dragData, out Sample_DragDropData dragData))
        {
            text.text = dragData.dataNum.ToString();
        }
    }
}
