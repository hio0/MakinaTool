using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Manager<InputManager>
{
    [SerializeField] InputActionAsset inputActions;

    InputActionRebindingExtensions.RebindingOperation rebindOperation;

    protected override void Awake()
    {
        AccessOn();
    }

    private void OnDisable()
    {
        CancelRebind();
        inputActions.Disable();
    }

    public void EnableMap(InputActionReference action)
    {
        action.action.actionMap.Enable();
    }

    public void DisableMap(InputActionReference action)
    {
        action.action.actionMap.Disable();
    }

    public void EnableAll()
    {
        inputActions.Enable();
    }

    public void DisableAll()
    {
        inputActions.Disable();
    }

    // Events
    public void AddStarted(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.started += callback;
    }

    public void AddPerformed(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.performed += callback;
    }

    public void AddCanceled(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.canceled += callback;
    }

    public void RemoveStarted(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.started -= callback;
    }

    public void RemovePerformed(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.performed -= callback;
    }

    public void RemoveCanceled(InputActionReference action, Action<InputAction.CallbackContext> callback)
    {
        action.action.canceled -= callback;
    }

    // Binding
    public void StartRebind(InputActionReference action, int bindingIndex, Action onStart, Action onCancel = null)
    {
        if (rebindOperation != null)
        {
            return;
        }

        InputAction target = action.action;

        if (bindingIndex < 0 || bindingIndex >= target.bindings.Count)
        {
            return;
        }

        if (target.bindings[bindingIndex].isComposite)
        {
            return;
        }

        rebindOperation = target.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(operation =>
            {
                operation.Dispose();
                rebindOperation = null;

                EventBus.Publish<Event_RebindComplete>(new Event_RebindComplete(target.GetBindingDisplayString(bindingIndex)));
            })
            .OnCancel(operation =>
            {
                operation.Dispose();
                rebindOperation = null;

                onCancel?.Invoke();
            });

        rebindOperation.Start();
        onStart?.Invoke();
    }

    public void CancelRebind()
    {
        rebindOperation?.Cancel();
    }

    public void ResetBinding(InputActionReference action, int bindingIndex)
    {
        InputAction target = action.action;

        if (bindingIndex < 0 || bindingIndex >= target.bindings.Count)
        {
            return;
        }

        target.RemoveBindingOverride(bindingIndex);
    }

    public void ResetAllBindings(InputActionReference action)
    {
        action.action.RemoveAllBindingOverrides();
    }

    public string GetBindingDisplay(InputActionReference action, int bindingIndex)
    {
        if (bindingIndex < 0 || bindingIndex >= action.action.bindings.Count)
        {
            return string.Empty;
        }

        return action.action.GetBindingDisplayString(bindingIndex);
    }

    // Binding Save
    public string ExportBindingOverrides()
    {
        return inputActions.SaveBindingOverridesAsJson();
    }

    public void ImportBindingOverrides(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return;
        }

        inputActions.LoadBindingOverridesFromJson(json);
    }
}

