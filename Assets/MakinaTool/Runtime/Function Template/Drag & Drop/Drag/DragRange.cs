using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Drag가 가능한 객체가 지니는 컴포넌트 입니다.
/// </summary>
[RequireComponent(typeof(TriggerObject))]
public class DragRange : MonoBehaviour
{
    protected TriggerObject trigger;

    protected virtual void Awake()
    {
        trigger = GetComponent<TriggerObject>();

        trigger.AddTrigger(EventTriggerType.BeginDrag, OnBeginDrag);
        trigger.AddTrigger(EventTriggerType.Drag, OnDrag);
        trigger.AddTrigger(EventTriggerType.EndDrag, OnEndDrag);
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
