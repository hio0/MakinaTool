using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextObject))]
public class DialogueBox : MonoBehaviour
{
    public DialogueData dialogueData { get; protected set; }

    [SerializeField] TextObject text;

    public virtual void Initialize(DialogueData dialogue)
    {
        dialogueData = dialogue;
    }


}
