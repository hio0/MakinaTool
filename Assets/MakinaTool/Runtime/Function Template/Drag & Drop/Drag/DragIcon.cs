using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Drag될 때 마우스를 따라가는 객체가 지니는 재너릭 컴포넌트. 단독 사용이 불가능합니다.
/// </summary>
/// <typeparam name="T">재너릭엔 받고자하는 데이터의 형식이 들어갑니다.</typeparam>
public abstract class DragIcon<T> : MonoBehaviour
{
    protected T dragData;

    [Header("드래그 아이콘")]
    [SerializeField] protected RectTransform rect;

    public virtual void Initialize(T data)
    {
        dragData = data;

        SetFront();
        StartCoroutine(MoveWithMouse());
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    /// <summary>
    /// 같은 canvas 상 객체들 중에 가장 위로 오게 됩니다.
    /// </summary>
    protected virtual void SetFront()
    {
        rect.SetAsLastSibling();
    }


    protected virtual IEnumerator MoveWithMouse()
    {
        Canvas canvas = GetComponentInParent<Canvas>();

        while (true)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 localPos);

            rect.anchoredPosition = localPos;
            yield return null;
        }
    }
}
