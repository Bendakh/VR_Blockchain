using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WebManager : InteractScript {

    public GameObject wtbCanvas;
    public Image productImage;
    public Text productInformation;
    public List<Item> itemList;
    public int displayedItem = 0;
	// Use this for initialization
	void Start () {

        LoadItemsFromLoader();
        DisplayItem(displayedItem);
        GameObject.FindGameObjectWithTag("Player").GetComponent<LoadingScrip>().timer = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadItemsFromLoader()
    {
        itemList = this.gameObject.GetComponent<ItemLoader>().items;
    }

    public void DisplayItem(int id)
    {
        string imagePath = itemList[id]._imagePath;
        Sprite tempImage = Resources.Load<Sprite>(imagePath);
        productImage.sprite = tempImage;
        productInformation.text = "Name: " + itemList[id]._name + "\n" + "Price: " + itemList[id]._price + "BTC";
    }

    
}
