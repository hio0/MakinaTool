using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LeanguageTrigger : MonoBehaviour
{
    public event Action<Locale> OnChangedLeanguage;

    protected virtual void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += ChangedLeanguage;
    }

    protected virtual void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= ChangedLeanguage;
    }

    protected virtual void ChangedLeanguage(Locale locale)
    {
        OnChangedLeanguage?.Invoke(locale);
    }
}
