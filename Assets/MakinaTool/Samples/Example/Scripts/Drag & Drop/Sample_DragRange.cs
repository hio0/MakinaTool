using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DragRange_Icon))]
public class Sample_DragRange : IdentitiyClass
{
    [Header("기능 클래스")]
    [SerializeField] DragRange_Icon dragRange;

    private void OnEnable()
    {
        dragRange.OnBeginDrag += BeginDrag;
    }

    private void OnDisable()
    {
        dragRange.OnBeginDrag -= BeginDrag;
    }

    void BeginDrag()
    {
        Sample_DragDropData dragData = new Sample_DragDropData
        {
            dataNum = Random.Range(1, 101)
        };

        dragRange.SetDragData(dragData);
    }
}
