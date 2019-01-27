using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signpost : InteractableObject
{
  

    bool powerOn = false;
    public GameObject brightLight;
    // Start is called before the first frame update
    protected override void Start()
    {
        //Get the event manager
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();

        powerOn = em.log.CheckEvent("powerOn");
        Debug.Log(powerOn);


        if (powerOn == true)
        {
            brightLight.SetActive(true);
        }
        else
        {
            brightLight.SetActive(false);
        }
           
        base.Start();
    }

    public override void ReceiveObject(string item = null)
    {
        //base.ReceiveObject(item);

        //Get the event manager
        EventManager em = GameObject.FindGameObjectWithTag("em").GetComponent<EventManager>();


        if (powerOn == false)
        {
            this.Activate();
            LogToScreen("The sign says: 'e'");

        }
        else
        {
            //Log "The light is too bright. You cannot read the sign.
            Debug.Log("There is too much light and sparks to read the sign.");
        }
    }

    protected override void Activate(int activationIndex = 0)
    {
       //Log "The sign displays the letter (whatever letter its supposed to display)
    }


}
