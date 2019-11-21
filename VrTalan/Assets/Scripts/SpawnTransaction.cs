using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTransaction : MonoBehaviour {
    public GameObject transactionPrefab;
    public string[] transactionArray;
    //private GameObject gm;
	// Use this for initialization
	void Start () {
        transactionArray = GameManager.manager.transactionsList.ToArray();
        //SpawnAllTransactions();
        StartCoroutine("SpawnAllTransactions");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.manager.buyingDone)
        {
            StartCoroutine("SpawnBuyingTransaction");
            GameManager.manager.buyingDone = false;
        }
	}


    IEnumerator SpawnBuyingTransaction()
    {
        yield return new WaitForSeconds(10f);
        GameObject tempTransaction = Instantiate(transactionPrefab, this.transform.position, this.transform.rotation);
        tempTransaction.GetComponent<SpawnedTransactionBehaviour>().buyingTransaction = true;
        tempTransaction.GetComponentInChildren<Text>().text = GameManager.manager.buyingTransaction;
        

    }

    IEnumerator SpawnAllTransactions()
    {
        Vector3 tempPosition;
        float tempYModificator;
        for(int i = 0; i < transactionArray.Length; i++)
        {
            tempYModificator = Random.Range(-1f, 1f);
            tempPosition = new Vector3(this.transform.position.x, (this.transform.position.y + tempYModificator), this.transform.position.z);
            yield return new WaitForSeconds(5f);
            GameObject tempTransaction = Instantiate(transactionPrefab, tempPosition, this.transform.rotation);
            tempTransaction.GetComponentInChildren<Text>().text = transactionArray[i];
        }
    }
}
