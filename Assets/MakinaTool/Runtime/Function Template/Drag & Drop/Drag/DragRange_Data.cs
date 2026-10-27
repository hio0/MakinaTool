using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRange_Data : DragRange
{
    public object dragData { get; protected set; }

    public virtual void SetDragData<T>(T data)
    {
        dragData = data;
    }
}
