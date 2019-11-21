using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashGenerator : MonoBehaviour {

    private static char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static char[] num = "1234567890".ToCharArray();


    // Use this for initialization
    void Start () {

        //alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //num = "1234567890".ToCharArray();
        //Debug.Log(Generate(64));
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public static string Generate(int n)
    {
        string temp = "0x";
        for(int i = 0; i < n; i++)
        {
            int per = Random.Range(0, 101);
            if (per > 66)
            {
                temp = temp + alpha[Random.Range(0, (alpha.Length))];
            }
            else
            {
                temp = temp + num[Random.Range(0, (num.Length))];
            }
        }
        return temp;
    }
}
