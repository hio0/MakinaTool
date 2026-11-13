using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleObject : AbilityClass
{
    [SerializeField] Toggle toggle;

    public virtual void SetOnOff(bool onOff)
    {
        toggle.isOn = onOff;
    }

    public virtual void AddListner(Action<bool> act)
    {
        toggle.onValueChanged.AddListener(act.Invoke);
    }

    public virtual void RemoveListner(Action<bool> act)
    {
        toggle.onValueChanged.RemoveListener(act.Invoke);
    }

    public virtual void ClearLister()
    {
        toggle.onValueChanged = null;
    }
}
