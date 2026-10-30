using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TriggerObject))]
public class DropRange : MonoBehaviour
{
    [SerializeField] TriggerObject trigger;

    public event Action OnDrop;

    protected virtual void Awake()
    {
        trigger.AddPointerEventTrigger(EventTriggerType.Drop, Drop);
    }

    protected virtual void Drop(PointerEventData eventData)
    {
        OnDrop?.Invoke();
    }
}
