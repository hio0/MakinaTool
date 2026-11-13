using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input/InputDatabase")]
public class InputDatabase : ScriptableObject
{
    [SerializeField] List<InputActionInfo> inputActions;
    [SerializeField] List<InputBindingInfo> inputIcons;

    public InputActionInfo GetAction(InputActionReference action)
    {
        return inputActions.Find(x => x.action == action);
    }

    public InputActionInfo GetActionToAction(InputAction action)
    {
        return inputActions.Find(x => x.action.action == action);
    }

    public InputBindingInfo GetBinding(string keycode)
    {
        return inputIcons.Find(x => x.key == keycode);
    }
}
