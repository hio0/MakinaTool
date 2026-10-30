using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LeanguageSetter : MonoBehaviour
{
    public virtual string GetNowLocale()
    {
        return LocalizationSettings.SelectedLocale.Identifier.Code;
    }

    public virtual void SetLeanguage(string code)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(code);

        if (locale != null)
        {
            LocalizationSettings.SelectedLocale = locale;
        }
    }
}
