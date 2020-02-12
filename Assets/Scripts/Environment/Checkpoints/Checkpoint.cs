using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	private GameMaster gm;
	[SerializeField] private GameObject disappearParticle;

	[SerializeField] private AudioClip checkpointActivated;
	AudioSource checkpointAS;
	//public float Volume;
	//public bool alreadyActive = false;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		
		checkpointAS = GetComponent<AudioSource>();

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")) {
			gm.lastCheckPointPos = transform.position;

			checkpointAS.PlayOneShot(checkpointActivated);

			GameObject spawnedParticle = Instantiate(disappearParticle, transform.position, transform.rotation);
			spawnedParticle.transform.parent = transform.root;
			Destroy(spawnedParticle, 5);

			//checkpointAS.PlayOneShot(checkpointActivated, Volume);
			//alreadyActive = true;
		}
    }
}
