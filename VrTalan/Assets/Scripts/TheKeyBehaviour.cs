using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKeyBehaviour : MonoBehaviour {

    //public bool stopped;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // if(!stopped)
       // {
            StartCoroutine("MoveKey");
       // }
		
	}

    IEnumerator MoveKey()
    {
        if (this.transform.position.x <= 410f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.right * 30f;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
            if (this.transform.rotation.eulerAngles.z <= 90f)
            {
                this.transform.Rotate(Vector3.forward* Time.deltaTime * 50f);
            }  
        }
        if (this.transform.rotation.eulerAngles.z >= 90f)
        {
            
            GameObject.FindGameObjectWithTag("Lock").GetComponent<InteractableLock>().unlocked = true;
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }

    }


}
