using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementsRefs : MonoBehaviour {


    public GameObject panel1;
    public GameObject panel2;
    public bool valueSelected;
    // Use this for initialization
    void Start () {
        valueSelected = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void DisplayTransactions()
    {
        if (GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().panel2.activeInHierarchy)
        {
            GameObject.Find("TransactionsText").GetComponent<Text>().text = "Transactions: " + "\n";
            foreach (string transac in GameManager.manager.transactionsList)
            {
                GameObject.Find("TransactionsText").GetComponent<Text>().text += transac + "\n";
            }
        }
    }
}
