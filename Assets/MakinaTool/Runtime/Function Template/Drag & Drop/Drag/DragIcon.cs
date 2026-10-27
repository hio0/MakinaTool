using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DragIcon : MonoBehaviour
{
    public object dragData { get; protected set; }

    [SerializeField] protected RectTransform rect;

    public event Action OnInitialize;

    public virtual void Initialize(object data)
    {
        dragData = data;

        SetFront();
        StartCoroutine(MoveWithMouse());

        OnInitialize?.Invoke();
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

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
