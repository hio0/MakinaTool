using System;
using System.Collections.Generic;

/// <summary>
/// 이벤트들을 보관하고 
/// </summary>
public class EventBus
{
    public Dictionary<Type, Action<IEvent>> eventList { get; private set; } = new();

    public virtual void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        Type type = typeof(T);
        Action<IEvent> wrapper = (e) => handler((T)e);

        if (!eventList.ContainsKey(type))
        {
            eventList[type] = delegate { };
        }

        eventList[type] += wrapper;
    }

    public virtual void Unsubscribe<T>(Action<T> handler) where T : IEvent
    {
        
    }

    public virtual void Publish<T>(T eventData) where T : IEvent
    {
        Type type = typeof(T);
        if (eventList.TryGetValue(type, out var handler))
        {
            handler.Invoke(eventData);
        }
    }
}
