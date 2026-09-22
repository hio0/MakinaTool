using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sample_DragIcon : DragIcon<Sample_DragDropData>
{
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = dragData.dataNum.ToString();   
    }
}
