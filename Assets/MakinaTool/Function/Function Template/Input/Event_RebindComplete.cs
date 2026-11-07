using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_RebindComplete : Event
{
    public string newBinding;

    public Event_RebindComplete(string newBinding)
    {
        this.newBinding = newBinding;
    }
}
