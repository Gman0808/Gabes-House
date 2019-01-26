using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLog : ScriptableObject
{
    //A list of all the events that have occured in the game.
    static Dictionary<string, bool> events = new Dictionary<string, bool>();

    public static void ToggleEvent(string eventName, bool eventOccured = true)
    {
        //If the event actually exists in the dictionary, mark its presence appropriately.
        if (events.ContainsKey(eventName))
        {
            events[eventName] = eventOccured;
        }
        else
        {
            Debug.Log("ERROR: Event key name not found.");
        }
    }

    //Used to determine whether events have happened or if they should be added to the log.
    //Events are added this way so that they only need to be defined in one piece of code to be recognized.
    public static bool EventOccured(string eventName)
    {
        //If the event doesn't exist in the dictionary.
        if (events.ContainsKey(eventName) == false)
        {
            events.Add(eventName, false);

        } //If the event name exists and it has occurred, return true.
        else if (events[eventName] == true)
        {
            return true;
        }

        //If the event didn't exist or it didn't happen, return false.
        return false;
    }

   
}
