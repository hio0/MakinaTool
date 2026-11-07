using System;
using UnityEngine.Localization;

[Serializable]
public class DialogueLine
{
    public SpeakerData speaker;
    public LocalizedString talk;

    //public List<StandingCommand> standingCommands = new();
    //public List<DialogueChoice> choices = new();
}
