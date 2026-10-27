using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(TriggerObject))]
public class DragRange : MonoBehaviour
{
    [SerializeField] TriggerObject trigger;

    public event Action OnBeginDrag;
    public event Action OnDrag;
    public event Action OnEndDrag;

    protected virtual void Awake()
    {
        trigger.AddTrigger(EventTriggerType.BeginDrag, BeginDrag);
        trigger.AddTrigger(EventTriggerType.Drag, Drag);
        trigger.AddTrigger(EventTriggerType.EndDrag, EndDrag);
    }

    protected virtual void OnDisable()
    {
        OnBeginDrag = null;
        OnDrag = null;
        OnEndDrag = null;
    }

    protected virtual void BeginDrag()
    {
        OnBeginDrag?.Invoke();
    }

    protected virtual void Drag()
    {
        OnDrag?.Invoke();
    }

    protected virtual void EndDrag()
    {
        OnEndDrag?.Invoke();
    }
}
