using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(ToggleObject))]
[RequireComponent(typeof(LeanguageSetter))]
public class LeanguageToggle : MonoBehaviour
{
    [Header("기능 클래스")]
    [SerializeField] ToggleObject toggle;
    [SerializeField] LeanguageSetter leanguageSet;

    [SerializeField] string myLocale;

    protected virtual void OnEnable()
    {
        CompareLocale();
        toggle.AddListner(ChangeLocale);
    }

    protected virtual void OnDisable()
    {
        toggle.RemoveListner(ChangeLocale);
    }

    protected virtual void CompareLocale()
    {
        string nowLocale = leanguageSet.GetNowLocale();
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
            leanguageSet.SetLeanguage(myLocale);
        }
    }
}
