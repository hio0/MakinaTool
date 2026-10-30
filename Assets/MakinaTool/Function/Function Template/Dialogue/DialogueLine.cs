using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(2, 5)]
    public string text;

    //public List<StandingCommand> standingCommands = new();
    //public List<DialogueChoice> choices = new();
}
