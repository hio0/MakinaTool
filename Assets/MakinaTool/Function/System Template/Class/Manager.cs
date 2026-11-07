using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager<T> : IdentitiyClass
    where T : Manager<T>
{
    public static T manager;

    protected abstract void Awake();

    protected virtual void Singleton()
    {
        if (manager == null)
        {
            manager = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void AccessOn()
    {
        manager = (T)this;
    }
}
