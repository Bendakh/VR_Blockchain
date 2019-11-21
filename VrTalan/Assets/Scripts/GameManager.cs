using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager manager;
    public Item itemToBuy;
    public string publicAddress;
    public string privateAddress;
    public bool publicKeyTaken;
    public bool privateKeyTaken;

    public float valueToBuy;
    public float pendingBalance;
    public float balance;

    public List<string> transactionsList = new List<string>();

    public string buyingTransaction = "";
    public bool buyingDone;

    private void Awake()
    {
        if(manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }
      
    }

    public void MoveToBlockChainMethod()
    {
        StartCoroutine("MoveToBlockchain");
    }

    IEnumerator MoveToBlockchain()
    {
        GameObject.Find("WebInterface").GetComponent<WebManager>().wtbCanvas.SetActive(true);
        GameObject.Find("WebInterface").SetActive(false);
        yield return new WaitForSeconds(4f);
        this.gameObject.GetComponent<Fading>().fadeOutTexture = (Texture2D) Resources.Load("WhiteScreen");
        float fadeTime = this.gameObject.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
      
        //yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }

    // Use this for initialization
    void Start () {
        publicKeyTaken = false;
        privateKeyTaken = false;
        balance = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
