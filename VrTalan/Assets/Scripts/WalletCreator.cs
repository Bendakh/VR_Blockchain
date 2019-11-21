using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WalletCreator : InteractScript {
    public GameObject publicKeyPrefab;
    public GameObject privateKeyPrefab;
    private ExperienceManager expManager;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
        expManager = GameObject.FindGameObjectWithTag("ExpManager").GetComponent<ExperienceManager>();
    }
	
	// Update is called once per frame
	void Update () {
        InteractWithMe();
        
	}


    public void InteractWithMe()
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {
                expManager.moving = true;
                
                ls.timer = 0f;
            }
        }
    }

    public void InstantiateGeneratedKeys()
    {
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().publicAddress = HashGenerator.Generate(64);
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().privateAddress = HashGenerator.Generate(64);
        StartCoroutine("InstantiateKeysAfterTime");
    }

    IEnumerator InstantiateKeysAfterTime()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject publicKey = Instantiate(publicKeyPrefab, new Vector3(transform.position.x + 0.3f, transform.position.y, (transform.position.z - 1.5f)), Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z)));
        GameObject privateKey = Instantiate(privateKeyPrefab, new Vector3((transform.position.x + 0.3f), (transform.position.y + 0.5f), (transform.position.z - 1.5f)), Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z)));
        publicKey.GetComponentInChildren<Text>().text = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().publicAddress;
        privateKey.GetComponentInChildren<Text>().text = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().privateAddress;
    }
}
