using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtMound : InteractableObject
{
    public GameObject key;


    protected override void Start()
    {
        base.Start();

        //The key should not exist normally.
        key.SetActive(false);

        //Get the event manager
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

       
        if (em.log.CheckEvent("Key2"))
        {
            this.tag = "Untagged";
        }

    }
    protected override void Activate(int activationIndex)
    {
        LogToScreen("You dug up a key with the melted spoon.");
        //Get the event manager
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        //Let the event manager know that this event has already occured.
        em.log.ToggleEvent(this.gameObject.name);

        //Sete the position of the key to above the dirt mound.
        key.transform.position = transform.position + Vector3.up;

        //Display some particle effects for dirt spewing.

        //Play a sound

        //Let the key exist.
        key.SetActive(true);


        matchingObjects.Clear();

    }
}
