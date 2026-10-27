using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectSpawner<T>
    where T : Component
{
    public ObjectPool<T> objectPool { get; set; }

    Component prefab;
    Transform parent;
    int poolSize;

    public event Func<T> OnCreateFunc;
    public event Action<T> OnGet;
    public event Action<T> OnRelease;
    public event Action<T> OnDestroy;

    public ObjectSpawner(T prefab, Transform parent, int maxsize)
    {
        this.prefab = prefab;
        this.parent = parent;
        poolSize = maxsize;
    }

    public virtual void InitializePool()
    {
        objectPool = new ObjectPool<T>(
           createFunc: OnCreateFunc,
           actionOnGet: OnGet,
           actionOnRelease: OnRelease,
           actionOnDestroy: OnDestroy,
           maxSize: poolSize
       );
    } 

    public virtual void ResetAction()
    {
        OnCreateFunc = null;
        OnGet = null;
        OnRelease = null;
        OnDestroy = null;
    }

    public void DefaultSet()
    {
        ResetAction();

        OnCreateFunc += DefaultCreateFunc;
        OnGet += DefaultGet;
        OnRelease += DefaultRelease;
        OnDestroy += DefaultDestroy;

        InitializePool();
    }

    public T Spawn()
    {
        T obj = objectPool.Get();

        return obj;
    }

    public void Despawn(T obj)
    {
        objectPool.Release(obj);
    }

    public void Clear()
    {
        objectPool.Clear();
    }

    public void Dispose()
    {
        objectPool.Dispose();
    }

    // 기본 세팅 
    T DefaultCreateFunc()
    {
        GameObject obj = UnityEngine.Object.Instantiate(prefab.gameObject, parent);

        return obj.GetComponent<T>();
    }

    void DefaultGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    void DefaultRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    void DefaultDestroy(T obj)
    {
        UnityEngine.Object.Destroy(obj.gameObject);
    }
}
