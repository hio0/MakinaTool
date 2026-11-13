using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingPanel : ModuleClass
{
    [SerializeField]

    public override void Activate()
    {
        InputManager.manager.OnRebindStart += BindingChanged;
    }

    public override void Deactivate()
    {
        InputManager.manager.OnRebindStart -= BindingChanged;
    }

    protected virtual void BindingChanged(InputAction act, int index)
    {

    }
}
