using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TriggerObject))]
public class DialogueTouchRange : MonoBehaviour
{
    [SerializeField] TriggerObject trigger;

    public event Action OnNextTalk;

    protected virtual void OnEnable()
    {
        trigger.AddTrigger(EventTriggerType.PointerClick, NextTalk);
    }

    protected virtual void OnDisable()
    {
        trigger.ResetTrigger();
    }

    protected virtual void NextTalk()
    {
        OnNextTalk?.Invoke();
    }
}
