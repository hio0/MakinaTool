using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TriggerObject))]
public class DropRange : ModuleClass
{
    [SerializeField] TriggerObject trigger;

    public event Action OnDrop;

    public override void Activate()
    {
        trigger.AddPointerEventTrigger(EventTriggerType.Drop, Drop);
    }

    protected virtual void Drop(PointerEventData eventData)
    {
        OnDrop?.Invoke();
    }
}
