using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이콘과 함께 값을 Drag로 이동시키는 객체가 지니는 재너릭 컴포넌트. 단독 사용이 불가능합니다.
/// </summary>
/// <typeparam name="T">재너릭엔 주고자하는 데이터의 형식이 들어갑니다.</typeparam>
public abstract class DragRange_Icon<T> : DragRange_Data<T>
{
    [Header("드래그")]
    [SerializeField] protected DragIcon<T> pre_dragIcon;
    protected DragIcon<T> nowIcon;

    protected override void OnBeginDrag()
    {
        Transform iconPos = GetComponentInParent<Canvas>().transform;

        nowIcon = Instantiate(pre_dragIcon, iconPos);
        nowIcon.Initialize(dragData);
    }

    protected override void OnEndDrag()
    {
        Destroy(nowIcon.gameObject);
        nowIcon = null;
    }
}
