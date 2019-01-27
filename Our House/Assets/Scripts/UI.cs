using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public UnityEngine.UI.Text textBox;
    public GameObject panel;
    public Image panelImage;

    bool displayText = false;

    string currentText = "";

    public int displayFrames = 340;

    public int maxCharWaitFrames = 2;
    int charWaitFrames;

    Queue<char> charQueue = new Queue<char>();



    public float maxLerpFrames = 100;
    float currentLerpFrames = 0;

    bool fading = false;

    public int maxTextDelayFrames = 180;
    int textDelayFrames; 
   
    // Start is called before the first frame update
    void Start()
    {
        panelImage = panel.GetComponent<Image>();
        textBox.color = panelImage.color = new Color(0, 0, 0, 0);
        textDelayFrames = maxTextDelayFrames;
    }

    // Update is called once per frame
    void Update()
    {
    
        
        if (displayText == true)
        {
            LerpTextDisplay();
       
        }
    
    }

    public void DisplayMessage(string text)
    {

        //The screen will display text
        displayText = true;

        //Clear anything from previous displaymessage calls
        currentText = "";

        //Things will appear on screen
        fading = false;

        //Allow for the text to wait a minute.
        textDelayFrames = maxTextDelayFrames;

        //Make sure the queue is good before displaying another message.
        charQueue.Clear();

        charWaitFrames = maxCharWaitFrames;

        currentLerpFrames = 0;

        for (int i = 0; i < text.Length; i++)
        {
            charQueue.Enqueue(text[i]);
        }


 
    }

    void LerpTextDisplay()
    {

        if (charQueue.Count>0)
        {
            --charWaitFrames;
            if (charWaitFrames <= 0)
            {
              
                charWaitFrames = maxCharWaitFrames;
                currentText += charQueue.Dequeue();
                textBox.text = currentText;

                Debug.Log("TESTINGTESTIGN");

            }
           
        }


        if (fading == false)
        {
            ++currentLerpFrames;

            --textDelayFrames;
            if (textDelayFrames<=0)
            {
                textDelayFrames = maxTextDelayFrames;
                fading = true;
            }
        }
        else
        {
            currentLerpFrames -= 2.7f;
        }

        float ratio = Mathf.LerpAngle(60, 0, currentLerpFrames / maxLerpFrames);
            panel.transform.rotation = Quaternion.Euler(ratio*2,ratio, ratio/5);

            
            panelImage.color = new Color(0, 0, 0, currentLerpFrames / maxLerpFrames);

            textBox.color = new Color(255,255, 255, currentLerpFrames / maxLerpFrames);


        
    }

    public void DisplayPickupMessage(string itemName)
    {
        DisplayMessage("You obtained a " + itemName + ".");
    }

 



  
}
