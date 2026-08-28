using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used: 드래그 시 마우스 포인터를 따라가는 아이콘 오브젝트들은 이 스크립트를 상속받으면 됩니다.
/// Used: 기본적으로, 드래그되는 오브젝트는 Initialize로 dragObject가 필요합니다. 이 dragObject 내 값을 이용해 무엇을 할지는 DragIcon을 상속받은 쪽이 알아서 결정합니다.
/// Used: 다만 기본 제공으로 spriteImage가 존재합니다. 드래그 시 나오는 아이콘에서, 기본적으로 dragObject에 따라 바뀔 이미지는 많이 쓰이는 기능이니 기본 제공합니다.
/// </summary>
public abstract class DragIcon : MonoBehaviour
{
    public object dragObject;

    public Image spriteImage;

    public virtual void Initialize(object dragObject)
    {
        this.dragObject = dragObject;
    }

    // ==============자식을 위한 템플릿================
    /// <summary>
    /// dragObject 내 Sprite로 spriteImage를 변경시킬 시 간편하게 변경시킬 수 있습니다.
    /// </summary>
    protected void SetSpriteImage(Sprite dragDataSprite)
    {
        if(spriteImage != null)
        {
            spriteImage.sprite = dragDataSprite;
        }
    }
}
