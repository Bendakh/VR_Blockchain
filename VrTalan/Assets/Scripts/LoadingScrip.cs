using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScrip : MonoBehaviour {


    public float timer;
    public float gazeTime = 1.5f;
    

    public Transform loadingBar;
    //float currentAmout;
    Image loadingImage;

	// Use this for initialization
	void Start () {
        loadingImage = loadingBar.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        loadingImage.fillAmount = timer / gazeTime;
	}
}
