using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBed : MonoBehaviour
{

    public float verticalForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the bed collides with a player object:
        if (collision.gameObject.tag == "player")
        {
            //Get the rigibody
            Rigidbody playerBod = collision.gameObject.GetComponent<Rigidbody>();

            //Add vertical force to the player
            playerBod.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);
        }
    }
}
