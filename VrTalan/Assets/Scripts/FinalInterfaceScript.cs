using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalInterfaceScript : MonoBehaviour {

    public Text infoText;
    public Image productImage;
    public Text productInformation;
    public GameObject player;

	// Use this for initialization
	void Start () {
        DisplayChosenProduct();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.manager.buyingDone)
        {
            StartCoroutine("ReturnToTheBlockchain");
        }
	}

    public void DisplayChosenProduct()
    {

        string imagePath = GameManager.manager.itemToBuy._imagePath;
        Sprite tempImage = Resources.Load<Sprite>(imagePath);
        productImage.sprite = tempImage;
        productInformation.text = "Name: " + GameManager.manager.itemToBuy._name + "\n" + "Price: " + GameManager.manager.itemToBuy._price + "BTC";
        infoText.text = "Your Public Key: " + GameManager.manager.publicAddress + "\n" + "Your balance: " + GameManager.manager.balance + "\n"; 
    }

    IEnumerator ReturnToTheBlockchain()
    {
        yield return new WaitForSeconds(3f);
        player.transform.position = GameObject.Find("PlayerPlaceHolder").transform.position;
        this.gameObject.SetActive(false);
    }
}
