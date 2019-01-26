using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trinket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pickup() 
    {
        //Get rid of this trinkets tag so it cant be picked up again.
        this.tag = null;

        //Delete the object 
        GameObject.DestroyImmediate(this);
    }
}
