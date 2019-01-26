using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public GameObject objectReference;

    int localObjects;

    GameObject exclamationPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void UseItem()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "interactable")
        {

            //Get a reference to the gameobject of the last thing that you touched.
            objectReference = collision.gameObject;

            ++localObjects;
            
            //Turn on the exclamation point
            exclamationPoint.SetActive(true);
        }
        else if (collision.gameObject.tag == "trinket")
        {
            //Uptick the number of trinkets
            inventory.trinkets++;

            //Do whatever the trinket needs to do before it dies.
            collision.gameObject.GetComponent<Trinket>().Pickup();
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        
        //If the player touches an interactable object
        if (collision.gameObject.tag == "interactable")
        {
            --localObjects;

            //If there are no more intereactable objects, 
            if (localObjects==0)
            {
                exclamationPoint.SetActive(false);
            }
        }
      
    }

    void GetInput()
    {

        if (localObjects>0)
        {
            //If the player is pressing the button to interact/pickup an item
            if (Input.GetButtonDown("interact") == true)
            {
                //If the player touched and object
                //This should be apparent though because localobjects is greater than 0
                //if (objectReference!=null)
                //{
                
                //Give the player's current object to the interactable object so thta it can check it.
                objectReference.GetComponent<InteractableObject>().ReceiveObject(inventory.GetCurrentItem()); 
                //}
             
            }

        }

    }




}
