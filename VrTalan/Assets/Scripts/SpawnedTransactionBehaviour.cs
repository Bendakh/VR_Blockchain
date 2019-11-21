using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedTransactionBehaviour : MonoBehaviour {
    public bool buyingTransaction;
    GameObject target;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public GameObject transactionParticleEffect;
    // Use this for initialization
    void Start () {
        
        target = GameObject.FindGameObjectWithTag("BlockSpawner");
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget(target);
	}

    private void MoveToTarget(GameObject go)
    {
        transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(go.transform.position.x, this.transform.position.y, go.transform.position.z - 2.8f), ref velocity, smoothTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BlockSpawner")
        {
            if (buyingTransaction)
            {
                Instantiate(transactionParticleEffect, this.transform.position, this.transform.rotation);
                target.GetComponent<SpawnBlock>().buyingTransactionArrived = true;
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(transactionParticleEffect, this.transform.position, this.transform.rotation);
                target.GetComponent<SpawnBlock>().transactionsArrived++;
                Destroy(this.gameObject);
            }
        }
    }
}
