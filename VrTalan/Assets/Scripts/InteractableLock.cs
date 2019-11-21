using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableLock : InteractScript {

    public Button buyButton;
    public GameObject privateKeyPrefab;
    private bool usable;
    public bool unlocked;
    // Use this for initialization
    void Start () {
        unlocked = false;
        usable = true;
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
    }
	
	// Update is called once per frame
	void Update () {
		if(!interacted && usable)
        {
            UnlockTheWallet();
        }
        if(unlocked)
        {
            //Unlock animation coroutine
            StartCoroutine("Unlocking");
        }
	}

    public void UnlockTheWallet()
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {

               
                ls.timer = 0f;
                StartCoroutine("SpawnTheKey");

                interacted = true;
                usable = false;
            }
        }
    }

    

    IEnumerator SpawnTheKey()
    {
        yield return new WaitForSeconds(1f);
        GameObject theKey = Instantiate(privateKeyPrefab, player.transform.position, Quaternion.Euler(0f,-90f,0f));
        theKey.GetComponentInChildren<Text>().text = GameManager.manager.privateAddress;
    }

    IEnumerator Unlocking()
    {
        
        yield return new WaitForSeconds(0.5f);
        Transform locker = this.gameObject.transform.GetChild(2);
        if(locker.transform.localPosition.y <= 0)
        {
            
            //locker.transform.parent = null;
            locker.GetComponent<Rigidbody>().velocity = Vector3.up * 10f;
          
        }


        if (locker.transform.position.y >= 0)
        {
            yield return new WaitForSeconds(1f);
            buyButton.GetComponent<BuyButtonScript>().isLocked = false;
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
        }
    }
}
