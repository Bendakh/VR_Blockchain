using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractScript : MonoBehaviour {


    public GameObject player;
    public LoadingScrip ls;
    protected bool isGazedAt;
    public bool interacted;
    // Use this for initialization
    void Start () {
        ls = GameObject.FindGameObjectWithTag("Player").GetComponent<LoadingScrip>();
        
	}
	
	// Update is called once per frame
	void Update () {

        

    }

    

    public void PointerEnter()
    {
        isGazedAt = true;
        
    }

    public void PointerExit()
    {
        isGazedAt = false;
        ls.timer = 0;
        interacted = false;
        
    }

    

}
