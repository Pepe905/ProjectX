using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrone : MonoBehaviour
{

    public float damage = 1;
    private Vector3 startPoint;
    [SerializeField] private float range = 100;

    public void Start()
    {
        startPoint = transform.position;
    }
    public void Update()
    {
        if ((transform.position - startPoint).magnitude >= range)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);

        }
    }








}
