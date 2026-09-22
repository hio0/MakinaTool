using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag가 값을 전달할 경우 그 값을 받는 객체가 상속받는 클래스입니다.
/// </summary>
/// <typeparam name="T">재너릭엔 받고자하는 데이터의 형식이 들어갑니다.</typeparam>
public abstract class DropRange_Data<T> : DropRange
{
    protected T dropData;

    protected override void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent<DragRange_Data<T>>(out DragRange_Data<T> dragRange))
        {
            dropData = dragRange.dragData;
        }
    }
}
