using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Drag로 값을 전달하는 객체가 상속받는 클래스입니다.
/// </summary>
/// <typeparam name="T">재너릭엔 주고자하는 데이터의 형식이 들어갑니다.</typeparam>
public abstract class DragRange_Data<T> : DragRange
{
    public T dragData { get; protected set; }

    protected virtual void SetDragData(T data)
    {
        dragData = data;
    }
}
