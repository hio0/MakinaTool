using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RebindingAbility))]
[RequireComponent(typeof(ButtonObject))]
public class RebindingButton : ModuleClass
{
    [SerializeField] protected RebindingAbility rebinding;
    [SerializeField] protected ButtonObject buttonObj;

    [SerializeField] protected InputActionReference targetAction;
    [SerializeField] protected int targetIndex;

    public override void Activate()
    {
        buttonObj.AddListener(StartRebinding);
    }

    public override void Deactivate()
    {
        buttonObj.RemoveListener(StartRebinding);
    }

    protected virtual void StartRebinding()
    {
        rebinding.StartRebind(targetAction, targetIndex);
    }
}