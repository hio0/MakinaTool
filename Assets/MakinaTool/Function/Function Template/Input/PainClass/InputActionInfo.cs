using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Input/InputActionInfo")]
public class InputActionInfo : ScriptableObject
{
    public InputActionReference action;

    public LocalizedString displayName;
}
