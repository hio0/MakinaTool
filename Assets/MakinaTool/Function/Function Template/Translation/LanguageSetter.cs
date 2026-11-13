using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageSetter : AbilityClass
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
