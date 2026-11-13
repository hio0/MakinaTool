using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public DialogueData dialogueData { get; protected set; }

    public virtual void Initialize(DialogueData dialogue)
    {
        dialogueData = dialogue;
    }


}
