using System;
using System.Collections.Generic;

public class EventBus
{
    public Dictionary<string, Delegate> eventList { get; private set; } = new();

    public virtual void Subscribe<T>(string id, Action<T> handler) where T : IEvent
    {
        if (eventList.TryGetValue(id, out var existing))
        {
            eventList[id] = Delegate.Combine(existing, handler);
        }
        else
        {
            eventList[id] = handler;
        }
    }

    public void Unsubscribe<T>(string id, Action<T> handler)
    {
        if (!eventList.TryGetValue(id, out var existing))
            return;

        eventList[id] = Delegate.Remove(existing, handler);
    }

    public void Publish<T>(string id, T data)
    {
        if (eventList.TryGetValue(id, out var handler))
        {
            ((Action<T>)handler).Invoke(data);
        }
    }
}
