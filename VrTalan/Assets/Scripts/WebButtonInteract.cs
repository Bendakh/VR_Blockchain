using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WebButtonInteract : InteractScript {


    WebManager webManagerScript;
    DropdownMenuScript dropDownMenuScript;
    GameManager gm;
	// Use this for initialization
	void Start () {
        ls = GameObject.FindGameObjectWithTag("Player").GetComponent<LoadingScrip>();
        webManagerScript = GameObject.Find("WebInterface").GetComponent<WebManager>();
        dropDownMenuScript = GameObject.Find("DropdownMenu").GetComponent<DropdownMenuScript>();
        gm = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
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

    public void NextItem()
    {
        webManagerScript.displayedItem++;
        if (webManagerScript.displayedItem >= webManagerScript.itemList.Count)
        {
            webManagerScript.displayedItem = 0;
        }
        webManagerScript.DisplayItem(webManagerScript.displayedItem);
    }

    public void PreviousItem()
    {
        webManagerScript.displayedItem--;
        if (webManagerScript.displayedItem < 0)
        {
            webManagerScript.displayedItem = webManagerScript.itemList.Count - 1;
        }
        webManagerScript.DisplayItem(webManagerScript.displayedItem);
    }

    public void ErrorButton()
    {
        if (!dropDownMenuScript.createWalletText.activeInHierarchy)
        {
            dropDownMenuScript.errorMessage.SetActive(true);
            StartCoroutine("Fade");
        }
    }

    public void BitCoinButton()
    {
        if (GameManager.manager.itemToBuy._name != "") {
            if (!dropDownMenuScript.errorMessage.activeInHierarchy)
            {
                dropDownMenuScript.createWalletText.SetActive(true);
            }

            dropDownMenuScript.createWalletButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Select an item");
        }
    }

    IEnumerator Fade()
    {
        if (dropDownMenuScript.errorMessage.activeInHierarchy)
        {
            yield return new WaitForSeconds(2f);
            dropDownMenuScript.errorMessage.SetActive(false);
        }
    }

    public void CreateAWalletButton()
    {
        //GameObject.Find("WebInterface").SetActive(false);
        //GameObject.FindGameObjectWithTag("Flash").SetActive(true);
        //SceneManager.LoadScene(2);
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().SendMessage("MoveToBlockChainMethod");
        //StartCoroutine("MoveToBlockchain");
    }

    /*IEnumerator MoveToBlockchain()
    {
        GameObject.Find("WebInterface").SetActive(false);
        GameObject.FindGameObjectWithTag("Flash").SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }*/

    public void AddToCartButton()
    {
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().itemToBuy = webManagerScript.itemList[webManagerScript.displayedItem];
    }
}
