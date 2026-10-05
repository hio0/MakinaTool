using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// EventTrigger를 사용하는 객체가 지니는 컴포넌트.
/// 변수명: trigger
/// </summary>
public class TriggerObject : MonoBehaviour
{
    [SerializeField] protected EventTrigger trigger;

    /// <summary>
    /// EventTrigger에 새 listner 추가하기
    /// </summary>
    /// <param name="type">어떤 조건일 때 실행시킬건가요?</param>
    /// <param name="act">어떤걸 실행시킬건가요? ( 매개변수 없는 함수 필요 )</param>
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

    /// <summary>
    /// EventTrigger에 특정 listner 제거
    /// </summary>
    /// <param name="type">어떤 조건일 때 실행시킬건가요?</param>
    public virtual void RemoveTrigger(EventTriggerType type)
    {
        trigger.triggers.RemoveAll(entry => entry.eventID == type);
    }

    /// <summary>
    /// EventTrigger 리셋
    /// </summary>
    public virtual void ResetTrigger()
    {
        trigger.triggers.Clear();
    }
}
