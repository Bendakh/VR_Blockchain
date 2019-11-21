using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DropdownMenuScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    public RectTransform container;
    public bool isOpen;
    public GameObject errorMessage;
    public GameObject createWalletText;
    public GameObject createWalletButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }

    // Use this for initialization
    void Start () {
        container = transform.Find("Container").GetComponent<RectTransform>();
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {

        DisplayDropDown();
       
	}

    private void DisplayDropDown()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }


    

    
}
