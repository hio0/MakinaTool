using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingAbility : AbilityClass
{
    public virtual void StartRebind(InputAction targetAction, int targetIndex)
    {
        InputManager.manager.StartRebind(targetAction, targetIndex);
    }

    public virtual void CancleRebind()
    {
        InputManager.manager.CancelRebind();
    }

    public virtual void ResetBinding(InputActionReference targetAction, int targetIndex)
    {
        InputManager.manager.ResetBinding(targetAction, targetIndex);
    }
    
    public virtual void ResetAllBinding(InputActionReference targetAction)
    {
        InputManager.manager.ResetAllBindings(targetAction);
    }

    public virtual void ResetAll()
    {
        InputManager.manager.ResetAll();
    }
}
