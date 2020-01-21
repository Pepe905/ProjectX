using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float timeDelay = 2f;
    float startTimer;

    public int damage = 10;
    public float explosiveForce = 20f;
    public float explosiveRadius = 15f;


    [SerializeField] private GameObject exploParticle;

    public GameObject ExploParticle { get => exploParticle; set => exploParticle = value; }

    void Update() {
        startTimer += Time.deltaTime;
        if (startTimer >= timeDelay) { 
            Explode(); //Function explode get called
        }
    }

    void Explode() // Function that gets called
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, explosiveRadius);

        for (int i = 0; i < coll.Length; i++) {
            if (coll [i].gameObject.GetComponent <TestDummy> ()) {
                coll[i].gameObject.GetComponent<TestDummy>().TakeDamage(damage);
                coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
            }
        }

        
        GameObject spawnedParticle = Instantiate(ExploParticle, transform.position, transform.rotation);
        Destroy(spawnedParticle, 5);
        /*
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        
            hasExploded = true;
            */
        Destroy(gameObject);
    }
}
