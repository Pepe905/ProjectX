using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	
	private GameMaster gm;
	[SerializeField] private GameObject disappearParticle;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			gm.lastCheckPointPos = transform.position;
			
			GameObject spawnedParticle = Instantiate(disappearParticle, transform.position, transform.rotation);
			spawnedParticle.transform.parent = transform.root;
			Destroy(spawnedParticle, 5);
		}
    }
}
