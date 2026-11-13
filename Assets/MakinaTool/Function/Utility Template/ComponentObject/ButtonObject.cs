using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonObject : AbilityClass
{
    [SerializeField] Button button;

    public virtual void AddListener(Action action)
    {
        button.onClick.AddListener(() => action?.Invoke());
    }

    public virtual void RemoveListener(Action action)
    {
        button.onClick.RemoveListener(() => action?.Invoke());
    }
}
