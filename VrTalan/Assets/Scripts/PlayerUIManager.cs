using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {

    public GameObject text;
    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {


        DisplayText();


    }

    public void DisplayText()
    {

        if(gm.publicKeyTaken && gm.privateKeyTaken)
        {
            text.GetComponent<Text>().text = "Your Public Key: " + gm.publicAddress + "\n" + "Your balance: " + gm.balance + "\n" + "Your pending balance: " + gm.pendingBalance;
        }

    }
}
