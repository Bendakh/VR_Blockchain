using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyCoinButtonInteract : InteractScript {
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
        interacted = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!interacted)
        {
            interactButton();

        }

    }

    private void interactButton()
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                ls.timer = 0f;
                interacted = true;
            }
        }
    }

    public void WelcomeButton()
    {
        GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().panel2.SetActive(true);
        GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().panel1.SetActive(false);
    }

    public void ValueButtonBehaviour()
    {
       
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().valueToBuy = float.Parse(this.gameObject.GetComponentInChildren<Text>().text);
        GameObject.Find("HowMuchToBuyText").GetComponent<Text>().text = "You are going to buy " + this.gameObject.GetComponentInChildren<Text>().text + " Bitcoins";
        GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().valueSelected = true;
    }

    public void BuyButton()
    {
        if (GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().valueSelected)
        {
            GameManager.manager.transactionsList.Add(HashGenerator.Generate(64));
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().pendingBalance += GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().valueToBuy;
            GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().valueToBuy = 0;
            GameObject.Find("HowMuchToBuyText").GetComponent<Text>().text = "";
            GameObject.Find("WebInterfaceBuyCoin").SendMessage("DisplayTransactions");
            GameObject.Find("WebInterfaceBuyCoin").GetComponent<UIElementsRefs>().valueSelected = false;
        }
    }

    public void ValidatePurchaseButton()
    {   if (GameManager.manager.pendingBalance > 0)
        {
            StartCoroutine("MoveToMining");
            GameObject.Find("WebInterfaceBuyCoin").GetComponent<GraphicRaycaster>().enabled = false;
        }
    }

    IEnumerator MoveToMining()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Fading>().fadeOutTexture = (Texture2D)Resources.Load("WhiteScreen");
        float fadeTime = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(4);
    }

    
}
