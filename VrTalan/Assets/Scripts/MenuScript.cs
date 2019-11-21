using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : InteractScript {

    // Use this for initialization
    void Start () {
        ls = GameObject.FindGameObjectWithTag("Player").GetComponent<LoadingScrip>();
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

    public void StartExperienceButton()
    {

        StartCoroutine("FadeToGame");

    }

    IEnumerator FadeToGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(1);
    }


    public void ExitGameButton()
    {
        Debug.Log("Exit game button works");
        Application.Quit();
    }

 
}
