using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript : MonoBehaviour
{

    public GameObject grenadePrefab;
    public Transform hand;
    public float throwForce = 10f;
    private int currentAmmo;
    private float nextTimeToFire = 0f;
    public int MaxAmmo = 5;
    public float fireRate = 15f;

    [SerializeField] private GameObject[] ammo;

    [SerializeField] Vector2 grenadeStartVelocity;

    void Start()

    {
            currentAmmo = MaxAmmo;

        for (int i = 0; i <= 2; i++)
        {
            ammo[i].gameObject.SetActive(true);
            nextTimeToFire = Time.time + 1f / fireRate;
            

        }
    }

  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            GameObject gren = Instantiate(grenadePrefab, hand.position, hand.rotation);
            gren.GetComponent<Rigidbody2D>().velocity = grenadeStartVelocity;
            currentAmmo--;
            ammo[currentAmmo].gameObject.SetActive(false);

            //gren.GetComponent<Rigidbody>().AddForce(hand.forward * throwForce, ForceMode.Impulse);
        }
    }
}
