using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sample_DropRange : DropRange_Data<Sample_DragDropData>
{
    protected override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        Debug.Log($"데이터: {dropData.dataNum}");
    }
}
