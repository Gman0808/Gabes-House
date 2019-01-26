using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float rotationAngle = 5;

    public float maxScale;
    public float minScale;

    public float maxScaleFrames = 18;
    float frames = 0;

    bool growing;

    float startingScale;

   
    // Start is called before the first frame update
    void Start()
    {
        startingScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationAngle);
        Pulse();
     }


    void Pulse()
    {

        if (growing)
        {

            ++frames;
            if (frames >= maxScaleFrames)
            {
                growing = false;
            }
        }
        else
        {
            --frames;
            if (frames <= 0)
            {
                growing = true;
            }
        }

        float ratio = Mathf.Lerp(minScale, maxScale, frames / maxScaleFrames);

        gameObject.transform.localScale = new Vector3(2 * ratio, .8f * ratio, ratio);

    }
}
