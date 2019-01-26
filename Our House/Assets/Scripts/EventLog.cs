using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "EventLog", menuName = "EventLog")]
public class EventLog : ScriptableObject
{
    //A list of all the events that have occured in the game.
   public Dictionary<string, bool> events = new Dictionary<string, bool>();

    List<string> eventNames;
    
    public void ToggleEvent(string eventName, bool add = true)
    {
        //If the event hasn't already happened yet
        if (eventNames.Contains(eventName) == false)
        {
            //Mark it as already having happend
            eventNames.Add(eventName);
        }
        else
        {

        }
    }

    public void CheckEvent()



    public void ToggleEvent(string eventName, bool eventOccured = true)
    {
        //If the event actually exists in the dictionary, mark its presence appropriately.
        //if (events.ContainsKey(eventName))
        //{
        //    events[eventName] = eventOccured;
        //}
        //else
        //{
        //    Debug.Log("ERROR: Event key name not found.");
        //}

        //If the toggled event isn't already contained in the log.
        if(events.ContainsKey(eventName) == false)
        {
            events.Add(eventName, true);
            Debug.Log("added " + eventName + " " + eventOccured);
        }
        else
        {
            Debug.Log(events[eventName]);
            events[eventName] = eventOccured;
            Debug.Log(events[eventName]);

        }
    }

    //Used to determine whether events have happened or if they should be added to the log.
    //Events are added this way so that they only need to be defined in one piece of code to be recognized.
    public bool CheckEventOccured(string eventName)
    {
        //If the event doesn't exist in the dictionary.
        if (events.ContainsKey(eventName) == false)
        {
            Debug.Log("the event hadn't previously occured");
            events.Add(eventName, false);

    

        } //If the event name exists and it has occurred, return true.
        else if (events[eventName] == true)
        {
            return true;
        }

        LogAllValues();


        //If the event didn't exist or it didn't happen, return false.
        return false;
    }
    
   public void LogAllValues()
    {

        foreach (KeyValuePair<string, bool> entry in events)
        {
            // do something with entry.Value or entry.Key
            Debug.Log(entry.Key);
        }
    }
   
}
