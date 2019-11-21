using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DestroyAfterFinished();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyAfterFinished()
    {
       
                Destroy(this.gameObject, this.GetComponent<ParticleSystem>().main.duration + this.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
            
        
    }
}
