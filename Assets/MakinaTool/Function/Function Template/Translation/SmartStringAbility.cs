using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class SmartStringAbility : AbilityClass
{
    public string GetSmartString(LocalizedString localizedString, Dictionary<string, object> arguments)
    {
        return localizedString.GetLocalizedString(new object[] { arguments });
    }
}
