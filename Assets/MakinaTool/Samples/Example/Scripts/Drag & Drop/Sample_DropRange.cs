using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DropRange_Data))]
public class Sample_DropRange : IdentitiyClass
{
    [Header("기능 클래스")]
    [SerializeField] DropRange_Data dropRange;

    void OnEnable()
    {
        dropRange.OnDrop += Drop;
    }

    void OnDisable()
    {
        dropRange.OnDrop -= Drop;
    }

    void Drop()
    {
        if (TryGetObject<Sample_DragDropData>(dropRange.dropData, out Sample_DragDropData dragData))
        {
            Debug.Log($"데이터: {dragData.dataNum}");
        }
    }
}
