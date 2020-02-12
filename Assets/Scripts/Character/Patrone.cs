using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrone : MonoBehaviour
{

    public float damage = 1;
    private Vector3 startPoint;
    [SerializeField] private float range = 100;
    //private AudioClip collectSound; https://answers.unity.com/questions/17856/sound-stops-when-object-is-destroyed.html

    public void Start()
    {
        startPoint = transform.position;
        Destroy(gameObject, 10f);
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
            //AudioSource.PlayClipAtPoint(collectSound, transform.position); https://answers.unity.com/questions/17856/sound-stops-when-object-is-destroyed.html
            Destroy(gameObject);
        }
    }
}
