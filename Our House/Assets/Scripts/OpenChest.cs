using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : InteractableObject
{
  public  GameObject finalKey;
    // Start is called before the first frame update
    private void Start()
    {
        finalKey = GameObject.Find("B.Key 2");
        tag = "interactable";

        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        bool hasActivated = em.log.CheckEvent(this.gameObject.name);

        if (hasActivated)
        {
            if (finalKey != null)
                finalKey.transform.position = new Vector3(-2.65f, 2.3f, 68.26f);
            
        }
        else
        {
            if (finalKey != null)
                finalKey.transform.position = new Vector3(-1000f, -1000f, -1000f);
        }

    }

    protected override void Activate(int activationIndex)
    {
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        em.log.ToggleEvent(this.gameObject.name);

        if (finalKey != null)
            finalKey.transform.position = new Vector3(-2.65f, 2.3f, 68.26f);
        //Turm off this gameObject

    }


}
