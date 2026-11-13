using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(ToggleObject))]
[RequireComponent(typeof(LanguageSetter))]
public class LanguageToggle : ModuleClass
{
    [Header("기능 클래스")]
    [SerializeField] ToggleObject toggle;
    [SerializeField] LanguageSetter leanguageSetter;

    [SerializeField] protected string myLocale;

    public virtual void Initialize(string locale)
    {
        myLocale = locale;
    }

    public override void Activate()
    {
        CompareLocale();
        toggle.AddListner(ChangeLocale);
    }

    public override void Deactivate()
    {
        toggle.RemoveListner(ChangeLocale);
    }

    protected virtual void CompareLocale()
    {
        string nowLocale = leanguageSetter.GetNowLocale();
        bool isOn = false;

        if(myLocale == nowLocale)
        {
            isOn = true;
        }

        toggle.SetOnOff(isOn);
    }

    protected virtual void ChangeLocale(bool isOn)
    {
        if(isOn)
        {
            leanguageSetter.SetLeanguage(myLocale);
        }
    }
}
