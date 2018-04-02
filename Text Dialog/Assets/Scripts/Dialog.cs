using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public float timeToWaitBetweenChars = .1f;
    public float timeToWaitBetweenNewLines = .5f;
    public float timeToAnimate = .57f;
    public string [] myString;
    private Text textUI;
    private IEnumerator coroutineTextView;
    private IEnumerator coroutineTextAnimate;
    bool animate = true;
    bool alreadyViewing = false;

	// Use this for initialization
	void Start ()
    {
        textUI = this.GetComponent<Text>();
        coroutineTextView = DialogText();
        textUI.text = "Press Space . . .";
        coroutineTextAnimate = DialogAnimate();
        StartCoroutine(coroutineTextAnimate);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //print(myString.Length);
        if (Input.GetKeyUp(KeyCode.Space) && alreadyViewing == false)
        {
            alreadyViewing = true;
            animate = false;
            StartCoroutine(coroutineTextView);
        }
        
	}
    private IEnumerator DialogAnimate()
    {
        while (animate)
        {
            textUI.text = "Press Space . . .";
            yield return new WaitForSeconds(timeToAnimate);
            textUI.text = null;
            yield return new WaitForSeconds(timeToAnimate);
        }
        
    }
    private IEnumerator DialogText()
    {
        
        textUI.text = null;
        yield return new WaitForSeconds(0.5f);
        int sizeOfArray = myString.Length - 1;
        int stringCounter = 0;
        int sizeOfEachString = 0;
        int charCounter = 0;
        string temp;
        while (stringCounter <= sizeOfArray)
        {
            sizeOfEachString = myString[stringCounter].Length - 1;
            temp = myString[stringCounter];
            charCounter = 0;
            while (charCounter <= sizeOfEachString)
            {
                textUI.text += temp[charCounter];
                charCounter++;
                yield return new WaitForSeconds(timeToWaitBetweenChars);
            }
            stringCounter++;
            textUI.text += "\n";
            yield return new WaitForSeconds(timeToWaitBetweenNewLines);
        }
      
    }
    
}
