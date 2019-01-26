using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.tag = "item";
        this.name = gameObject.name;

        //Get the event manager.
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

      
        //The gameobject should destroy itself immediately if it has already been picked up.
        if (em.log.CheckEventOccured(gameObject.name) == true)
        {
            Destroy(gameObject);
        }
    }

}
