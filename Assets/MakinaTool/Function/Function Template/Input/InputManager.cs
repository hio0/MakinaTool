using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Manager<InputManager>
{
    public InputActionAsset inputActions { get; private set; }
    public InputDatabase inputDatabase { get; private set; }

    InputActionRebindingExtensions.RebindingOperation rebindOperation;

    public event Action<InputAction, int> OnRebindStart;
    public event Action<InputAction, InputAction, int> OnReBindingComplete;
    public event Action<InputAction, int> OnRebindComplete;
    public event Action OnRebindCanceled;

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
    public void StartRebind(InputAction target, int bindingIndex)
    {
        if (rebindOperation != null)
        {
            return;
        }

        if (bindingIndex < 0 || bindingIndex >= target.bindings.Count)
        {
            return;
        }

        if (target.bindings[bindingIndex].isComposite)
        {
            return;
        }

        rebindOperation = target.PerformInteractiveRebinding(bindingIndex)
            .OnPotentialMatch(operation =>
            {
                string newPath = operation.selectedControl.path;

                if (TryFindDuplicateBinding(newPath, target, bindingIndex, out InputAction duplicateAction, out int duplicateIndex))
                {
                    InputAction oldInput = duplicateAction;
                    InputAction newInput = target;

                    duplicateAction.ApplyBindingOverride(duplicateIndex, "");

                    OnReBindingComplete?.Invoke(oldInput, newInput, bindingIndex);
                }
            })
            .OnComplete(operation =>
            {
                operation.Dispose();
                rebindOperation = null;

                OnRebindComplete?.Invoke(target, bindingIndex);
            })
            .OnCancel(operation =>
            {
                operation.Dispose();
                rebindOperation = null;

                OnRebindCanceled?.Invoke();
            });

        rebindOperation.Start();
        OnRebindStart?.Invoke(target, bindingIndex);

        bool TryFindDuplicateBinding(string path, InputAction target, int bindingIndex, out InputAction duplicateAction, out int duplicateIndex)
        {
            foreach (InputAction action in inputActions)
            {
                for (int i = 0; i < action.bindings.Count; i++)
                {
                    if (action == target && i == bindingIndex)
                    {
                        continue;
                    }

                    if (action.bindings[i].effectivePath == path)
                    {
                        duplicateAction = action;
                        duplicateIndex = i;
                        return true;
                    }
                }
            }

            duplicateAction = null;
            duplicateIndex = -1;
            return false;
        }
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

    public void ResetAll()
    {
        inputActions.RemoveAllBindingOverrides();
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

