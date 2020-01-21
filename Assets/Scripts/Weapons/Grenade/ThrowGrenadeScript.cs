using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript : MonoBehaviour
{

    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 10f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject gren = Instantiate(grenadePrefab, hand.position, hand.rotation) as GameObject;
            gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
        }
    }
}
