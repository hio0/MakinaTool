using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Drag를 Drop받는 오브젝트가 지니는 컴포넌트.
/// </summary>
[RequireComponent(typeof(TriggerObject))]
public class DropRange : MonoBehaviour
{
    protected TriggerObject trigger;

    protected virtual void Awake()
    {
        trigger = GetComponent<TriggerObject>();

        trigger.AddPointerEventTrigger(EventTriggerType.Drop, OnDrop);
    }

    protected virtual void OnDrop(PointerEventData eventData)
    {

    }
}
