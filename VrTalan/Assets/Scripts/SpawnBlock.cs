using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
    //public GameObject terminal;
    public GameObject blockPrefab;
    public GameObject ASpecialblockPrefab;
    public GameObject transactionblockPrefab;

    public float spawnDelay;
    public Vector3 tempPosition;
    public int transactionsCount;
    public int transactionsArrived;
    private bool allTransactionsArrived;
    public bool buyingTransactionArrived;
    // Use this for initialization
    void Start () {
        allTransactionsArrived = false;
        transactionsCount = GameManager.manager.transactionsList.Count;
        transactionsArrived = 0;
        //Position où les blocks vont s'empiler, A NE PAS EFFACER AHAM VARIABLE FIL SCENE!!
        tempPosition = new Vector3(-71f, 50f, -9.35f);
        InvokeRepeating("SpawnBlockAfterDelay", 0f, spawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
        if(transactionsArrived >= transactionsCount)
        {
            allTransactionsArrived = true;
            //Debug.Log("DONE DONE DONE!");
        }
	}


    private void SpawnBlockAfterDelay()
    {   if (allTransactionsArrived)
        {
            Instantiate(ASpecialblockPrefab, this.transform.position, this.transform.rotation);
            transactionsArrived = 0;
            allTransactionsArrived = false;
            //StartCoroutine("SpawnTerminal");
        }
        else if (buyingTransactionArrived)
        {
            Instantiate(transactionblockPrefab, this.transform.position, this.transform.rotation);
            buyingTransactionArrived = false;
        }
        else
        {
            Instantiate(blockPrefab, this.transform.position, this.transform.rotation);
        }
    }
}
