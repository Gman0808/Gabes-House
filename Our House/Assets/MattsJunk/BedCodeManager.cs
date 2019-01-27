using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedCodeManager : MonoBehaviour
{
   public bool puzzleOver = false;
   public int count = 0;
  GameObject key;
    string[] bedList = { "Yellow", "Blue", "Red", "Blue", "Green", "Brown" };
    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Brothers Key");
    }
   public  void check(string bed)
    {
        if (!puzzleOver)
        {
            if (bed == bedList[count])
            {
                Debug.Log("Correct");
                count++;
            }
            else
            {
                Debug.Log("Fail");
                count = 0;
            }
        }
        
    }
   
  
    // Update is called once per frame
    void Update()
    {
        if (count == 6)
        {
            puzzleOver = true;
            key.transform.position = new Vector3(-30, 20, -30);
            count++;
        }
            
        if (!puzzleOver)
        {
            key.transform.position = new Vector3(200, 20, -30);
        }
        
    }
}
