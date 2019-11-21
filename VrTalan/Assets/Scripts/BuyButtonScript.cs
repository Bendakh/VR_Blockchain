using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonScript : InteractScript {

    public Text transactionHash;
    public bool isLocked;

	// Use this for initialization
	void Start () {
        isLocked = true;
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocked)
        {
            BuyTheProduct();
        }
	}

    public void BuyTheProduct()
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {

                GameManager.manager.pendingBalance = GameManager.manager.itemToBuy._price * -1;
                ls.timer = 0f;
                transactionHash.gameObject.SetActive(true);
                string tempTransaction = HashGenerator.Generate(64);
                GameManager.manager.buyingTransaction = tempTransaction;
                GameManager.manager.buyingDone = true;
                transactionHash.text = "Transaction: " + "\n" + tempTransaction;
                this.gameObject.SetActive(false);

            }
        }
    }

    
}
