using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader : MonoBehaviour {
    public List<Item> items;
    public Dictionary<int, Item> itemList;
    private void Awake()
    {
        itemList = new Dictionary<int, Item>();
        
        ItemDictionary dictionary = JsonUtility.FromJson<ItemDictionary>(JsonFileReader.LoadJsonAsResource("ItemDictionary"));
        foreach(string dictionaryItem in dictionary.items)
        {
            LoadItem(dictionaryItem);
        }

        foreach(KeyValuePair<int, Item> entry in itemList)
        {
            Item temp = entry.Value;
            items.Add(temp);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadItem(string path)
    {
        string loadedItem = JsonFileReader.LoadJsonAsResource(path);
        Item item = JsonUtility.FromJson<Item>(loadedItem);
        itemList.Add(item._id,item);
    }
}
