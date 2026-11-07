using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextObject : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public virtual void SetText(string log)
    {
        text.text = log;
    }
}
