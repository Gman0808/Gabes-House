using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : InteractableObject
{
    // Start is called before the first frame update
    private void Start()
    {
        tag = "interactable";

        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        bool hasActivated = em.log.CheckEvent(this.gameObject.name);

        if (hasActivated)
        {
            gameObject.SetActive(false);
        }

    }

    protected override void Activate(int activationIndex)
    {
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        em.log.ToggleEvent(this.gameObject.name);

        //Turm off this gameObject
        gameObject.SetActive(false); 
    }
}
