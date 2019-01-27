using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    //List<string> messages = new List<string>();

    public List<string> matchingObjects = new List<string>();
    public List<string> responseStrings = new List<string>();

    protected virtual void Start()
    {
        tag = "interactable";
    }
    //Pass in the player's current item
    public virtual void ReceiveObject(string item = null)
    {

        //For each item that the interactible object can match with
        for (int i = 0; i < matchingObjects.Count; i++)
        {

            //If the player is inputting an item that matches:
            if (matchingObjects[i].ToUpper() == item.ToUpper())
            {
          
                //Do a thing, passing in the index of the thing we want to activate with.
                Activate(i);
            }
            else
            {
                LogToScreen("fuck you.");
            }
        }
    }

    //Perform a different action depending on the context of the situation.
    protected virtual void Activate(int activationIndex = 0)
    {

    }

    protected virtual void LogToScreen(string text)
    {
        UI userInterface = GameObject.FindGameObjectWithTag("player").GetComponent<UI>();

        userInterface.DisplayMessage(text);
    }


}
