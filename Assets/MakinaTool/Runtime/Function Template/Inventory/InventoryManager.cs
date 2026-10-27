using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryManager<T> : MonoBehaviour
{
    public List<T> nowinventory { get; private set; } = new();

    public Action<T> OnAdded;
    public Action<T> OnRemoved;

    protected virtual void Awake()
    {
        OnAdded += AddInventory;
        OnRemoved += RemoveInventory;
    }

    protected virtual void AddInventory(T data)
    {
        nowinventory.Add(data);
    }

    protected virtual void RemoveInventory(T data)
    {
        nowinventory.Remove(data);
    }

    protected virtual void ClearInventory()
    {
        nowinventory.Clear();
    }
}
