using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingBlocks : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();

    int fadeIndex = 0;

    enum BlockState
    {
        active, 
        fading, 
        gone
    }
    BlockState currentState = BlockState.fading;

    public int maxFadeFrames;
    int framesBeforeFade;
    // Start is called before the first frame update
    void Start()
    {
        framesBeforeFade = maxFadeFrames;
    }

    // Update is called once per frame
    void Update()
    {

        //If the blocks are in the middle of fading
        if (currentState == BlockState.fading)
        {
            //Count down the number of frames before the next one fades.
            --framesBeforeFade;

            if (framesBeforeFade <= 0)
            {
                framesBeforeFade = maxFadeFrames;
                blocks[fadeIndex].SetActive(false);

                ++fadeIndex;
                if (fadeIndex == blocks.Count)
                {
                    currentState = BlockState.gone;
                }
            }
        }
    }
}
