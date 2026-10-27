using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollObject : MonoBehaviour
{
    public ScrollRect scroll {  get; protected set;  }
    [SerializeField] public Transform content;

    protected virtual void Awake()
    {
        scroll = GetComponent<ScrollRect>();
    }

    public virtual void SoftInstantiate(GameObject obj, int times)
    {
        IEnumerator Cor()
        {
            for (int i = 0; i < times; i++)
            {
                Instantiate(obj, content);
                yield return null;
            }
        }

        StartCoroutine(Cor());
    }
}
