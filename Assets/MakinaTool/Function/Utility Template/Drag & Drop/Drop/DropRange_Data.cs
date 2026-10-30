using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropRange_Data : DropRange
{
    public object dropData { get; protected set; }

    protected override void Drop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<DragRange_Data>(out DragRange_Data dragRange))
        {
            dropData = dragRange.dragData;
        }

        base.Drop(eventData);
    }
}
