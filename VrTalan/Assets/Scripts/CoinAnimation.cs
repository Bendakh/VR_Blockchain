using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetFloat("cycleOffset", Random.Range(0f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
