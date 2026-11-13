using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSource
{
    public InputActionReference action { get; protected set; }
    
    public InputEventType eventType { get; protected set; }

    public event Action<InputAction.CallbackContext> OnInput;

    bool isSubscribed;

    public virtual void Initialize(InputActionReference action, InputEventType eventType)
    {
        if (isSubscribed)
        {
            Unsubscribe();
        }

        this.action = action;
        this.eventType = eventType;
    }

    public virtual void Subscribe()
    {
        if (isSubscribed || action == null)
        {
            return;
        }

        switch (eventType)
        {
            case InputEventType.Started:
                InputManager.manager.AddStarted(action, HandleInput);
                break;
            case InputEventType.Performed:
                InputManager.manager.AddPerformed(action, HandleInput);
                break;
            case InputEventType.Canceled:
                InputManager.manager.AddCanceled(action, HandleInput);
                break;
        }

        isSubscribed = true;
    }

    public virtual void Unsubscribe()
    {
        if (!isSubscribed)
        {
            return;
        }

        switch (eventType)
        {
            case InputEventType.Started:
                InputManager.manager.RemoveStarted(action, HandleInput);
                break;
            case InputEventType.Performed:
                InputManager.manager.RemovePerformed(action, HandleInput);
                break;
            case InputEventType.Canceled:
                InputManager.manager.RemoveCanceled(action, HandleInput);
                break;
        }

        isSubscribed = false;
    }

    protected virtual void HandleInput(InputAction.CallbackContext context)
    {
        OnInput?.Invoke(context);
    }
}
