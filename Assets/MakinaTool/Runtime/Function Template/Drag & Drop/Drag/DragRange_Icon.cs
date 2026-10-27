using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRange_Icon : DragRange_Data
{
    protected ObjectSpawner<DragIcon> iconSpawner;

    [SerializeField] protected DragIcon pre_dragIcon;
    [SerializeField] protected Transform iconPos;

    protected DragIcon nowIcon;

    protected override void Awake()
    {
        base.Awake();

        iconSpawner = new ObjectSpawner<DragIcon>(pre_dragIcon, iconPos, 5);
        iconSpawner.DefaultSet();
    }

    protected override void BeginDrag()
    {
        base.BeginDrag();

        nowIcon = iconSpawner.Spawn();
        nowIcon.Initialize(dragData);
    }

    protected override void EndDrag()
    {
        base.EndDrag();

        iconSpawner.Despawn(nowIcon);
        nowIcon = null;
    }
}
