using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingKeysBehaviour : InteractScript {
    public float speed = 1f;
    public float amplitude = 0.005f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        transform.position = new Vector3(transform.position.x, this.transform.position.y + Mathf.Sin(Time.time * speed) * amplitude, transform.position.z);
	}

    


    
}
