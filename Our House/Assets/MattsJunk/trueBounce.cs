using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trueBounce : MonoBehaviour
{
    public float verticalForce = 10;
    public string name = "bed";
    float timer;
    BedCodeManager manger;
    // Start is called before the first frame update
    void Start()
    {
        timer = 500;
        manger = GameObject.FindGameObjectWithTag("bounceManger").GetComponent<BedCodeManager>();
    }

    private void Update()
    {
        timer += 1 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the bed collides with a player object:
        if (other.gameObject.tag == "player")
        {
            //Get the rigibody
            Movement playerBod = other.gameObject.GetComponent<Movement>();


            playerBod.directionMove += (Vector3.up * verticalForce * Time.deltaTime);
            //Add vertical force to the player

      if(timer >= 4)
            manger.check(name);
            timer = 0;
        }
    }
}
