using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string loadName = "Test Scene";
    public GameObject warpTo = null;

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
                manager.MovePlayerPosition(warpTo.transform.position, collision.gameObject);
            }
            else
            {
                Debug.Log(loadName);
                Debug.Log("LOAD SCENE");
                //Load the specified scene using the transition manager
                TransitionManager manager = GameObject.FindGameObjectWithTag("tm").GetComponent<TransitionManager>();
                manager.LoadScene(loadName);
            }
        } 
    }
}
