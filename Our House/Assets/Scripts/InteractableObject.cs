using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    //List<string> messages = new List<string>();

    public List<string> matchingObjects = new List<string>();

    //Pass in the player's current item
    public void ReceiveObject(string item)
    {

        //For each item that the interactible object can match with
        for (int i = 0; i < matchingObjects.Count; i++)
        {

            //If the player is inputting an item that matches:
            if (matchingObjects[i] == item)
            {
                //Do a thing, passing in the index of the thing we want to activate with.
                Activate(i);
            }
        }
    }

    //Perform a different action depending on the context of the situation.
    void Activate(int activationIndex)
    {

    }


}
