using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BindingAbility : AbilityClass
{
    public virtual string GetBindingPath(InputAction action, int bindingIndex)
    {
        return action.bindings[bindingIndex].effectivePath;
    }

    public virtual string GetBindingDisplay(InputAction action, int bindingIndex)
    {
        return action.GetBindingDisplayString(bindingIndex);
    }

    public virtual InputBindingInfo GetBindingInfo(string keycode)
    {
        return InputManager.manager.inputDatabase.GetBinding(keycode);
    }
}
