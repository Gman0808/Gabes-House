using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Pixelation.Example.Scripts;

public class TransitionManager : MonoBehaviour
{
    //Camera playerCamera = null;
    Pixelation camPixels;
    float startingPixelNumber = 261;

    SpriteRenderer blackCover;



    /// <summary>
    /// Enums
    /// </summary>
    public enum TransitionStates
    {
        waiting,
        fading,
        unfading,
        
    }
    public static TransitionStates currentState = TransitionStates.unfading;

    public enum LoadMode
    {
        loading,
        movingPlayer,
        none
    }
    public static LoadMode currentLoadMode = LoadMode.none;



    /// <summary>
    /// Lerp Values
    /// </summary>
    /// 
    //The number of frames it should take to transition normal to pixelated & opaque to black.
    public float maxTransitionFrames = 500;
    public float transitionFrames = 0;

    public float maxDarkenFrames = 500;
    public float darkenFrames = 0;

    float ratio = 0;



    /// <summary>
    /// Transition Values
    /// </summary>
    GameObject player = null;
    Vector3 newPosition = Vector3.zero;

    string sceneToLoad = null;



   

    // Start is called before the first frame update
    void Start()
    {
        camPixels = Camera.main.GetComponent<Pixelation>();
        blackCover = Camera.main.GetComponentInChildren<SpriteRenderer>();

        //transitionFrames = maxTransitionFrames;
        //darkenFrames = maxDarkenFrames;

        //The number of pixels that the starting camera has
        startingPixelNumber = camPixels.BlockCount;

        SetTransitionState(TransitionStates.unfading);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TransitionStates.waiting:
                return;//NOTICE THIS

            case TransitionStates.fading:

                
                --transitionFrames;
                --darkenFrames;

                
                // This segment uses lerp to detmerine the values of the screen blackness and pixelation

                float ratio = Mathf.Lerp(64, startingPixelNumber, transitionFrames / maxTransitionFrames);
                camPixels.BlockCount = ratio;

                float blackRatio = Mathf.Lerp(1, 0, darkenFrames/ maxDarkenFrames);



                blackCover.color = new Color(blackCover.color.r, blackCover.color.g, blackCover.color.b, blackRatio);


                //If the screen is black
                if (darkenFrames<=0)
                {
                    #region Transition

                    switch (currentLoadMode)
                    {
                        case LoadMode.loading:

                            //Load the scene
                            SceneManager.LoadScene(sceneToLoad);
                            currentLoadMode = LoadMode.none;

                            break;

                        case LoadMode.movingPlayer:

                            Debug.Log("movePlayer");
                            //Move the player to the new position
                            player.transform.position = newPosition;

                            //Clear out the values for the player stuff, as it isn't needed anymore.
                            newPosition = Vector3.zero;
                            player = null;

                            break;

                        //case LoadMode.none:
                        //    break;
                        default:
                            break;
                    }
                    #endregion Transition

                    SetTransitionState(TransitionStates.unfading);
                }

                break;

            case TransitionStates.unfading:

                ++transitionFrames;
                ++darkenFrames;

                ratio = Mathf.Lerp(64, startingPixelNumber, transitionFrames / maxTransitionFrames);
                camPixels.BlockCount = ratio;

                ratio = Mathf.Lerp(1, 0, darkenFrames / maxDarkenFrames);

                blackCover.color = new Color(blackCover.color.r, blackCover.color.g, blackCover.color.b, ratio);


                if (darkenFrames >= maxDarkenFrames)
                {
           
                    SetTransitionState(TransitionStates.waiting);
                }

                break;
 
            default:
                break;
        }

    
    }


    public void LoadScene(string sceneName)
    {
        currentLoadMode = LoadMode.loading;

        //Load the specified scene.
        sceneToLoad = sceneName;
        SetTransitionState(TransitionStates.fading);
    }

    public void MovePlayerPosition(Vector3 positionToMove, GameObject playerReference)
    {
        
        currentLoadMode = LoadMode.movingPlayer;
        newPosition = positionToMove;
        player = playerReference;

        SetTransitionState(TransitionStates.fading);
    }

    public void SetTransitionState(TransitionStates passState)
    {
        currentState = passState;
        

        switch (currentState)
        {

            case TransitionStates.waiting:
                blackCover.gameObject.SetActive(false);
                //Debug.Log("turnOff");
                break;

            case TransitionStates.fading:

                blackCover.gameObject.SetActive(true);
                darkenFrames = maxDarkenFrames;
                transitionFrames = maxTransitionFrames;
                blackCover.color = new Color(blackCover.color.r, blackCover.color.g, blackCover.color.b, 0);

                break;

            case TransitionStates.unfading:
               
                darkenFrames = 0;
                transitionFrames = 0;
                blackCover.color = new Color(blackCover.color.r, blackCover.color.g, blackCover.color.b, 1);
                break;
      
            default:
                break;
        }
    }

   

}
