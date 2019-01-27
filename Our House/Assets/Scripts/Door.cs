using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string loadName = "Test Scene";
   static public string warp= null;
     public string warpTo = null;
    public GameObject warpObject = null;


    public void Start()
    {
       if(warp != null)
        {
            warpObject = GameObject.Find(warp);
            GameObject player = GameObject.FindGameObjectWithTag("player");

            //Move the player to the location of the warpTo object

            // manager.MovePlayerPosition(warpObject.transform.position, player);
            player.transform.position = warpObject.transform.position;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        //If the door collides with the player.
        if (collision.gameObject.tag == "player")
        {
          
            //If there is no string to load a scene.
            if (loadName=="NONE" || loadName == "")
            {

                //Move the player to the location of the warpTo object
                TransitionManager manager = GameObject.FindGameObjectWithTag("tm").GetComponent<TransitionManager>();
                
                manager.MovePlayerPosition(warpObject.transform.position, collision.gameObject);
            }
            else
            {
                warp = warpTo;
                Debug.Log(loadName);
                Debug.Log("LOAD SCENE");
                //Load the specified scene using the transition manager
                TransitionManager manager = GameObject.FindGameObjectWithTag("tm").GetComponent<TransitionManager>();
                manager.LoadScene(loadName);
              //  warpObject = GameObject.Find(warp);
               // manager.MovePlayerPosition(warpObject.transform.position, collision.gameObject);

            }
        } 
    }
}
