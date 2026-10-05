using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인벤토리 시스템을 관리하고 데이터를 보관하는 매니져 객체의 재너릭 클래스. 단독 사용이 불가능합니다. 
/// </summary>
/// <typeparam name="T">재너릭엔 해당 인벤토리가 보관하는 값의 형식을 넣습니다.</typeparam>
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
