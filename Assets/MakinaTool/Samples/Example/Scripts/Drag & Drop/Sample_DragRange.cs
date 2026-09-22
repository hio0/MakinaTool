using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_DragRange : DragRange_Icon<Sample_DragDropData>
{
    protected override void OnBeginDrag()
    {
        Sample_DragDropData dragData = new Sample_DragDropData
        {
            dataNum = Random.Range(1, 101)
        };
        SetDragData(dragData);

        base.OnBeginDrag();
    }
}
