using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFloor : MonoBehaviour {

    public float scrollSpeed = 0.25f;
    private Renderer floorRenderer;
    //Vector2 offset = Vector2.zero;
    //public Vector2 animationRate = new Vector2(0.0f, -1.0f);
    
    // Use this for initialization
    void Start () {
        floorRenderer = this.gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        animateFloor();
        
        
	}

    private void animateFloor()
    {
        float offset = Time.time * scrollSpeed;
        floorRenderer.material.SetTextureOffset("_MainTex", new Vector2(0f, -offset));
    }
}
