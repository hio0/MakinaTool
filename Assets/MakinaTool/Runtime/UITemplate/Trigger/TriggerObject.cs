using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// EventTrigger를 사용하는 오브젝트들이 상속하는 클래스입니다.
/// </summary>
public abstract class TriggerObject : MonoBehaviour
{
    [Header("트리거")]
    [SerializeField] protected EventTrigger trigger;

    /// <summary>
    /// EventTrigger에 새 listner 추가하기
    /// </summary>
    /// <param name="type">어떤 조건일 때 실행시킬건가요?</param>
    /// <param name="act">어떤걸 실행시킬건가요? ( 매개변수 없는 함수 필요 )</param>
    protected virtual void AddTrigger(EventTriggerType type, Action act)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = type
        };
        entry.callback.AddListener(_ => act());

        trigger.triggers.Add(entry);
    }

    protected virtual void AddPointerEventTrigger(EventTriggerType type, Action<PointerEventData> act)
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
    protected virtual void RemoveTrigger(EventTriggerType type)
    {
        trigger.triggers.RemoveAll(entry => entry.eventID == type);
    }

    /// <summary>
    /// EventTrigger 리셋
    /// </summary>
    protected virtual void ResetTrigger()
    {
        trigger.triggers.Clear();
    }
}
