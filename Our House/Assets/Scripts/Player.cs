using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public GameObject objectReference;

    int localObjects;

    public GameObject exclamationPoint;

    UI playerUI;


    // Start is called before the first frame update
    void Start()
    {
        playerUI = gameObject.GetComponent<UI>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "interactable" || collision.gameObject.tag == "item")
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
        if (collision.gameObject.tag == "interactable" || collision.gameObject.tag == "item")
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


                if (objectReference.tag == "item")
                {

                
                    //Get a temporary reference to the object.
                    GameObject itemToPickup = objectReference;

                    //Debug.Log(itemToPickup);

                    //Get rid of our more permanant object reference.
                    //objectReference = null;

                    //Pick up the item
                    inventory.PickupItem(objectReference);

                    playerUI.DisplayPickupMessage(objectReference.name);

                    

                    --localObjects;
                    if (localObjects <=0)
                    {
                        localObjects = 0;
                        exclamationPoint.SetActive(false);
                    }
                }
                //If the player touched and object
                //This should be apparent though because localobjects is greater than 0
                //if (objectReference!=null)
                //{


            
                if (objectReference.tag == "interactable" && inventory.items.Count>0) 
                {
                   
                    objectReference.GetComponent<InteractableObject>().ReceiveObject(inventory.GetCurrentItem());
                }
                //Give the player's current object to the interactable object so thta it can check it.
      
                //}
             
            }

        }


        if (Input.GetButtonDown("cycle") == true)
        {

         
            if (Input.GetAxis("cycle") > 0)
            {
                inventory.CycleItem(true);
                

            }
            else if (Input.GetAxis("cycle") < 0)
            {
                inventory.CycleItem(false);
      
            }
        }
       

    }




}
