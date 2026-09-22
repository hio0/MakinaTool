using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Drag가 가능한 객체가 상속하는 클래스입니다.
/// </summary>
public abstract class DragRange : TriggerObject
{
    protected virtual void Awake()
    {
        AddTrigger(EventTriggerType.BeginDrag, OnBeginDrag);
        AddTrigger(EventTriggerType.Drag, OnDrag);
        AddTrigger(EventTriggerType.EndDrag, OnEndDrag);
    }

    protected virtual void OnBeginDrag()
    {
        
    }

    protected virtual void OnDrag()
    {
        
    }

    protected virtual void OnEndDrag()
    {
        
    }
}
