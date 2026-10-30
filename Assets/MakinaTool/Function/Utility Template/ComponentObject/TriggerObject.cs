using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class TriggerObject : MonoBehaviour
{
    [SerializeField] EventTrigger trigger;

    public virtual void AddTrigger(EventTriggerType type, Action act)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = type
        };
        entry.callback.AddListener(_ => act());

        trigger.triggers.Add(entry);
    }

    public virtual void AddPointerEventTrigger(EventTriggerType type, Action<PointerEventData> act)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = type
        };
        entry.callback.AddListener(data =>
        {
            act((PointerEventData)data);
        });

        trigger.triggers.Add(entry);
    }

    public virtual void RemoveTrigger(EventTriggerType type)
    {
        trigger.triggers.RemoveAll(entry => entry.eventID == type);
    }

    public virtual void ResetTrigger()
    {
        trigger.triggers.Clear();
    }
}
