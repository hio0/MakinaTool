using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sample_SampleEvent : IEvent
{
    public string newMassage;

    public Sample_SampleEvent(string massage)
    {
        newMassage = massage;
    }
}
