using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEnding : InteractScript {

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LoadingScrip>();
    }
	
	// Update is called once per frame
	void Update () {
        WarpToLastScene();
	}

    public void WarpToLastScene()
    {
        if (isGazedAt)
        {
            ls.timer += Time.deltaTime;
            if (ls.timer >= ls.gazeTime)
            {

                ls.timer = 0f;
                StartCoroutine("MoveToLastScene");
                //this.gameObject.SetActive(false);


            }
        }
    }

    IEnumerator MoveToLastScene()
    {
        GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Fading>().fadeOutTexture = (Texture2D)Resources.Load("WhiteScreen");
        float fadeTime = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(5);
    }
}
