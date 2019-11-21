using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Item {

    //public List<Item> items;
    //private string gameDataFileName = "data.json";


    /*private string _name;
    private string _imagePath;
    private float _price;

    public string Name { get { return _name; } set { _name = value; } }
    public string ImagePath { get { return _imagePath; } set { _imagePath = value; } }
	public float Price { get { return _price; } set { _price = value; } }*/

    public int _id;
    public string _name;
    public string _imagePath;
    public float _price;
}
