using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Used: dragObject에 원하는 값을 넣고, 읽는 쪽에서 이 스크립트의 dragObject를 읽어 값을 드래그로 전달합니다.
/// Used: pre_dragIcon은 만약 드래그 시 마우스 포인터에 보여줄 아이콘이 있다면 넣습니다. 아이콘이 DragIcon을 상속하고 있어야 합니다.
/// Used: 드래그 오브젝트 쪽에서, 드래그 때 넘길 값인 dragObject는 Initialize로 설정해야 합니다.
/// </summary>
public class DragRange : MonoBehaviour
{
    public object dragObject;

    [SerializeField] EventTrigger tirgger;
    [SerializeField] DragIcon pre_dragIcon;
    DragIcon nowIcon;

    public void Initialize(object dragObject)
    {
        this.dragObject = dragObject;
    }

    private void Awake()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        nowIcon = Instantiate(pre_dragIcon, CameraCanvas.Instance.cameraTransform);
        nowIcon.Initialize(dragObject);

        MoveWithMouse();
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveWithMouse();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(nowIcon);
        nowIcon = null;
    }

    void MoveWithMouse()
    {
        /*
        RectTransform parentRect = basicIcon.transform.parent as RectTransform;


        basicIcon.GetComponent<RectTransform>().anchoredPosition = localPos;
        */
    }
}
