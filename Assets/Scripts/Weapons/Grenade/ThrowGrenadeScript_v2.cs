using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript_v2 : MonoBehaviour
{

    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 50000f;
    GameObject gren;
    //public Animator m_animator; //only needed if palyer or object doesnt have a own animator

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Animator>().SetTrigger("isThrowing");
            //if plyer or object doesnt ahve n animator itself
            //m_animator.SetTrigger("isThrowing");

            gren = Instantiate(grenadePrefab, hand.position + new Vector3(0, 0), hand.rotation ) as GameObject;
        }
        if (gren != null)
        {
            //gren.transform.position = Vector3.Lerp(hand.position, hand.position + new Vector3(2, 0), Time.deltaTime);

            //gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
            gren.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0) * throwForce, ForceMode.Impulse);

        }
    }
}
