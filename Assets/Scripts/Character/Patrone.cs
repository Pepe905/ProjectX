using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrone : MonoBehaviour
{

    public float damage = 1;

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            other.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }








}
