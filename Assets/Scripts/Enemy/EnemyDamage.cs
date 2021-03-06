﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] EnemyHealth enemyHealth;

	public float damage;
	public float damageRate;
	public float pushBackForce;
	float nextDamage;
	Animator enemyAC;

	// Use this for initialization
	void Start () {
		nextDamage = Time.time;
		enemyAC = transform.parent.GetComponentInChildren<Animator>();
		//Debug.Log(enemyAC);
	}

	void OnTriggerStay2D(Collider2D other){
		if (enemyHealth.hasDied)
			return;

		if (other.tag == "Player" && nextDamage < Time.time)
		{
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;
			PushBack (other.transform);
			enemyAC.SetTrigger("isAttacking");
		}
	}

	void PushBack(Transform pushedObject){
		Vector2 pushDirection = new Vector2 (0, (pushedObject.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
		
}
