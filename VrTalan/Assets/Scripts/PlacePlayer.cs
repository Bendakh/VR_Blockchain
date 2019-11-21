using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
