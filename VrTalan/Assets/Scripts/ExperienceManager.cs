using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperienceManager : MonoBehaviour {
    public GameObject creatorCanvas;
    public GameObject player;
    public bool moving;
    public GameObject creator;
    private GameManager gm;
    
    //public static ExperienceManager expManager;
    // Use this for initialization


    /*private void Awake()
    {
        if (expManager == null)
        {
            DontDestroyOnLoad(gameObject);
            expManager = this;
        }
        else if (expManager != this)
        {
            Destroy(gameObject);
        }
    }*/

    void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.GetChild(0).GetChild(3).GetComponent<PlayerUIManager>().text.SetActive(true);
        creator = GameObject.FindGameObjectWithTag("Creator");
        moving = false;
        gm = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            creator.GetComponent<BoxCollider>().enabled = false;
            player.GetComponent<PlayerBehaviourScript>().SendMessage("GoTo", creator);
        }

        if(player.transform.position.z >= (creator.transform.position.z - 3.1f))
        {
            creatorCanvas.SetActive(true);
            moving = false;
            //creator.transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.FindGameObjectWithTag("Finish").SetActive(true);
        }

        MoveToBuyingCoins();

    }

    private void MoveToBuyingCoins()
    {
        if(gm.publicKeyTaken && gm.privateKeyTaken)
        {
            StartCoroutine("WaitAndMoveToBuyingCoins");
        }
    }

    IEnumerator WaitAndMoveToBuyingCoins()
    {
        yield return new WaitForSeconds(2f);
        gm.GetComponent<Fading>().fadeOutTexture = (Texture2D)Resources.Load("WhiteScreen");
        float fadeTime = gm.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(3);
    }
}
