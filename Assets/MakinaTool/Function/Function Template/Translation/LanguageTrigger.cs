using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageTrigger : AbilityClass
{
    public event Action<Locale> OnChangedLeanguage;

    public override void Activate()
    {
        LocalizationSettings.SelectedLocaleChanged += ChangedLeanguage;
    }

    public override void Deactivate()
    {
        LocalizationSettings.SelectedLocaleChanged -= ChangedLeanguage;
    }

    protected virtual void ChangedLeanguage(Locale locale)
    {
        OnChangedLeanguage?.Invoke(locale);
    }
}
