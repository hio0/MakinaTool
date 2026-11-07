using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextObject))]
public class BindingGetter_Text : BindingGetter
{
    [SerializeField] TextObject textObj;

    protected override void GetSetBinding()
    {
        base.GetSetBinding();

        textObj.SetText(myKey);
    }
}
