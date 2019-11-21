using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour {

    Transform cubeTransform;
    public float speed;

	// Use this for initialization
	void Start () {
        cubeTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        cubeTransform.RotateAround(Vector3.zero, Vector3.up, speed);
	}
}
