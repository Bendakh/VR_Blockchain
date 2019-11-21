using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour {

    public float letterPause = 0.1f;

    string message;
    Text writtenText;
	// Use this for initialization
	void Start () {
        writtenText = GetComponent<Text>();
        message = writtenText.text;
        writtenText.text = "";
        StartCoroutine("TypeText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TypeText()
    {
        foreach(char letter in message.ToCharArray())
        {
            writtenText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
