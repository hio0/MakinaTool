using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public abstract class IdentitiyClass : MonoBehaviour
{
    protected virtual bool TryGetObject<T>(object obj, out T data)
    {
        if (obj is T)
        {
            data = (T)obj;
            return true;
        }
        else
        {
            data = default;
            return false;
        }
    }

}
