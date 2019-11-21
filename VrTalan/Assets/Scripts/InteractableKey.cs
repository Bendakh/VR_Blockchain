using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableKey : InteractScript {

    //public GameObject keySprite;
    public string keyType;
    public AudioSource aus;
    public AudioClip sound;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
    }
	
	// Update is called once per frame
	void Update () {
        TakeMe(keyType);
	}

    public void TakeMe(string keyType)
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {

                AudioSource.PlayClipAtPoint(sound, this.gameObject.transform.position);
                GameObject.Find(keyType).GetComponent<Image>().sprite =  Resources.Load<Sprite>("key");
                GameObject.Find(keyType).GetComponent<Image>().color = new Color(GameObject.Find(keyType).GetComponent<Image>().color.r, GameObject.Find(keyType).GetComponent<Image>().color.g, GameObject.Find(keyType).GetComponent<Image>().color.b, 255f);
                if (keyType == "PrivateKeyImage")
                    GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().privateKeyTaken = true;
                else if (keyType == "PublicKeyImage")
                    GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>().publicKeyTaken = true;
                ls.timer = 0f;
                Destroy(this.gameObject);
               

            }
        }
    }

    
}
