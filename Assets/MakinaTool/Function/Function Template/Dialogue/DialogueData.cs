using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    public List<DialogueLine> lines = new();
}
