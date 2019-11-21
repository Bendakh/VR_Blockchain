using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreatorMenuScript : InteractScript {
    
    //private GameManager gameManagerScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //gameManagerScript = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        ls = player.GetComponent<LoadingScrip>();
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
            }
        }
    }

    // Update is called once per frame
    void Update () {
        interactButton();
	}

    public void GenerateKeys()
    {
        GameObject.FindGameObjectWithTag("Creator").SendMessage("InstantiateGeneratedKeys");
        this.gameObject.SetActive(false);
        
    }
}
