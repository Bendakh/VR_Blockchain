using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimateTexture : MonoBehaviour {


    public float scrollSpeed = 0.5f ;
    private Renderer blockRenderer;
	// Use this for initialization
	void Start () {
        blockRenderer = this.gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimateBlock();
	}

    private void AnimateBlock()
    {
        float offset = Time.time * scrollSpeed;
        blockRenderer.material.SetTextureOffset("_MainTex", new Vector2(0f, -offset));
    }
}
