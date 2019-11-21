using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour {
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;

    public static PlayerBehaviourScript thePlayer;
    // Use this for initialization

    private void Awake()
    {
        if (thePlayer == null)
        {
            DontDestroyOnLoad(gameObject);
            thePlayer = this;
        }
        else if (thePlayer != this)
        {
            Destroy(gameObject);
        }
    }


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoTo(GameObject go)
    {
        transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(go.transform.position.x,go.transform.position.y,go.transform.position.z - 2.8f), ref velocity,smoothTime);
    }
}
