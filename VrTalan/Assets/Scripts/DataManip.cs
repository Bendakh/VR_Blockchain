using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManip : MonoBehaviour {


    private string gameDataFileName = "data.json";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            //Traitement
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

}
