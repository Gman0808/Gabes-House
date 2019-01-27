using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerInventory", menuName = "PlayerInventory")]
public class Inventory : ScriptableObject
{

    public int currentItem = 0;
    public List<string> items = new List<string>();

    public int trinkets = 0;

    //public EventLog eLogger = null;


    public void CycleItem(bool forward)
    {
        //If the player has no items, just leave.
        if (items.Count < 2)
        {
            return;
        }

        
        Debug.Log("blarg");
        
        if (forward==true)
        {
           

            //If the current item ISN'T the last item in tfhe inventory
            if (currentItem != items.Count-1 )
            {
                //Move to the next item.
                ++currentItem;
            }
            else
            {
                //If the current item is the last item in the list:
                //Cycle back to the first item in the list.
                currentItem = 0;
            }
        }
        else //If cycling backwards
        {
            
            //If the current item ISN'T the FIRST item.:
            if(currentItem != 0)
            {
                currentItem--;
            }
            else
            {
                //If the current item is the first item:
                //Cycle to the end of the list. 
                currentItem = items.Count - 1;
            }
        }

        Debug.Log(currentItem);
    }

    void AddItem(string newItem)
    {

        Debug.Log("test");
        items.Add(newItem);
    }

    void RemoveItem(int itemIndex)
    {
        //If the item index is innapropriate.
        if (itemIndex>=items.Count || itemIndex<=0)
        {
            Debug.Log("ERROR: Innapropriate item remove-at index: " + itemIndex);
            return;
        }

        items.RemoveAt(itemIndex);
    }

    void RemoveItem(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            //If the item name matches the inputted name, get rid of the item at the index
            if(items[i] == itemName)
            {
                //Remove the item at the index if it matches with the name
                items.RemoveAt(i);
            }
        }
    }


    //Return the string of the current item
    public string GetCurrentItem()
    {
        Debug.Log(currentItem);
        return items[currentItem];
    }

    public void PickupItem(GameObject itemToPickup)
    {

        AddItem(itemToPickup.name);

        //display a textbox saying that the item has been added.

        //Get the event manager.
        GameObject em = GameObject.FindGameObjectWithTag("em");

        //Log the fact that the item has been picked up!
        em.GetComponent<EventManager>().log.ToggleEvent(itemToPickup.name);

        GameObject.Destroy(itemToPickup);

    }


    

    

   
}
