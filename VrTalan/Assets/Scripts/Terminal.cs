using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : InteractScript {

    public GameObject secondaryPlaceholder;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
        secondaryPlaceholder = GameObject.Find("SecondaryPlaceHolder");
    }
	
	// Update is called once per frame
	void Update () {
        TeleportUser();
	}

    public void TeleportUser()
    {
        
            if (isGazedAt)
            {
                ls.timer += Time.deltaTime;
                if (ls.timer >= ls.gazeTime)
                {
                    
                    ls.timer = 0f;
                    player.transform.position = secondaryPlaceholder.transform.position;
                    secondaryPlaceholder.SendMessage("ActivateTheInterface");
                    this.gameObject.SetActive(false);


                }
            }
        
    }
}
