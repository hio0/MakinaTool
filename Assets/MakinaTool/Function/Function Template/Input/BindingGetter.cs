using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BindingGetter : MonoBehaviour
{
    [SerializeField] protected InputActionReference myInput;
    [SerializeField] protected int myBindingIndex;

    protected string myKey { get; private set; }

    protected virtual void GetSetBinding()
    {
        myKey = InputManager.manager.GetBindingDisplay(myInput, myBindingIndex);
    }
}
