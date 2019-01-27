using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{

    public  Material matOff;
    public Material matOn;
    public GameObject[] lights;
    public bool power;
    
   public  int[] lightsOn = { 0, 0, 0, 0, 0 }; //0-lights off, 1- lights on

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("lightbulb");
        power = true;
     
    }

    // Update is called once per frame
    void Update()
    {
        power = true;
        for (int i = 0; i < 5; i++)
        {
            if(lightsOn[i] == 0)
            {
                power = false;
                lights[i].GetComponent<MeshRenderer>().material = matOff;
            }
            else if(lightsOn[i] == 1)
            {
                lights[i].GetComponent<MeshRenderer>().material = matOn;
            }
            else
            {
                lightsOn[i] = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
            hit1();
        if (Input.GetKeyDown(KeyCode.F2))
            hit2();
        if (Input.GetKeyDown(KeyCode.F3))
            hit3();
        if (Input.GetKeyDown(KeyCode.F4))
            hit4();
        if (Input.GetKeyDown(KeyCode.F5))
            hit5();

    }

    void hit1()
    {
        lightsOn[0]++;
        lightsOn[2]++;
        lightsOn[3]++;
    }
    void hit2()
    {
        lightsOn[1]++;
        lightsOn[3]++;
        lightsOn[4]++;

    }
    void hit3()
    {
        lightsOn[1]++;
        lightsOn[2]++;
        lightsOn[3]++;
    }
    void hit4()
    {
        lightsOn[4]++;

      
    }
    void hit5()
    {
        lightsOn[4]++;
        lightsOn[0]++;
        lightsOn[3]++;
    }
}
