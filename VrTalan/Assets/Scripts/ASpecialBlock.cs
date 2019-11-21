using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASpecialBlock : MonoBehaviour {
    public GameObject terminal;
    public bool movingV;
    public bool movingH;
    private GameObject blockSpawner;
    public bool stopped;
    // Use this for initialization
    void Start()
    {
        stopped = false;
        blockSpawner = GameObject.FindGameObjectWithTag("BlockSpawner");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Mathf.Clamp(this.gameObject.transform.position.y, -50f, 50f);
        if (this.gameObject.transform.position.y <= 50f && !movingV && !movingH)
        {
            movingV = true;
        }

        if (this.gameObject.transform.position.y >= 50f && movingV && !movingH)
        {
            movingV = false;
            movingH = true;
        }

        if (this.gameObject.transform.position.x <= blockSpawner.GetComponent<SpawnBlock>().tempPosition.x && movingH)
        {
            movingV = false;
            movingH = false;

        }

        MoveSpecialBlock();

    }


    public void MoveSpecialBlock()
    {
        if (movingV && !movingH)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
        }

        if (!movingH && !movingV)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (!stopped)
            {
                blockSpawner.GetComponent<SpawnBlock>().tempPosition.x += 4;
                stopped = true;
                GameManager.manager.balance = GameManager.manager.pendingBalance;
                GameManager.manager.pendingBalance = 0;
                Instantiate(terminal, new Vector3(-2.91f, 3.37f, 0f), Quaternion.identity);
            }

        }

        if (!movingV && movingH)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-7.5f, 0f, 0f);
        }
    }
}
