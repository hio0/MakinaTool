using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public static class EventBus
{
    private static readonly Dictionary<Type, Delegate> events = new();

    public static void Subscribe<T>(Action<T> callback)
        where T : Event
    {
        Type type = typeof(T);

        if (events.TryGetValue(type, out Delegate existing))
        {
            events[type] = Delegate.Combine(existing, callback);
        }
        else
        {
            events[type] = callback;
        }
    }

    public static void Unsubscribe<T>(Action<T> callback)
        where T : Event
    {
        Type type = typeof(T);

        if (!events.TryGetValue(type, out Delegate existing))
        {
            return;
        }

        Delegate result = Delegate.Remove(existing, callback);

        if (result == null)
        {
            events.Remove(type);
        }
        else
        {
            events[type] = result;
        }
    }

    public static void Publish<T>(T eventData)
        where T : Event
    {
        if (events.TryGetValue(typeof(T), out Delegate callback))
        {
            ((Action<T>)callback)?.Invoke(eventData);
        }
    }

    public static void ClearAllEvent()
    {
        events.Clear();
    }
}
