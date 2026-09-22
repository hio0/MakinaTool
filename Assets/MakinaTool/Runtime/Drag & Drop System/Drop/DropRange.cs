using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag를 Drop받는 오브젝트가 상속받는 클래스입니다.
/// </summary>
public abstract class DropRange : TriggerObject
{
    protected virtual void Awake()
    {
        AddPointerEventTrigger(EventTriggerType.Drop, OnDrop);
    }

    protected abstract void OnDrop(PointerEventData eventData);
}
