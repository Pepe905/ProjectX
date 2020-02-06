using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript : MonoBehaviour
{

    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 10f;

    [SerializeField] Vector2 grenadeStartVelocity;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject gren = Instantiate(grenadePrefab, hand.position, hand.rotation);
            gren.GetComponent<Rigidbody2D>().velocity = grenadeStartVelocity;
            //gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
        }
    }
}
