using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFileReader {

    public static string LoadJsonAsResource(string path)
    {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonFile = Resources.Load<TextAsset>(path);
        return loadedJsonFile.text;
    }
}
