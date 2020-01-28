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

    void Update()
    {

        startTimer += Time.deltaTime;
        if (startTimer >= timeDelay)
        {
            Explode(); //Function explode gets called
        }
    }

    bool h_hasExploded = false; //h_ = helper Variable
    void Explode() // Function that gets called
    {
        if (h_hasExploded)
            return;
        h_hasExploded = true;

        Collider2D[] coll = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explosiveRadius);

        Debug.LogWarning(coll.Length);

        for (int i = 0; i < coll.Length; i++)
        {
            EnemyHealth eh = coll[i].gameObject.GetComponent<EnemyHealth>();
            if (eh)
            {
                eh.ApplyDamage(damage);
                //coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
            }
            /*
            playerHealth ph = coll[i].gameObject.GetComponent<playerHealth>();
            if (ph)
            {
                ph.addDamage(damage);
            }
            */
        }


        GameObject spawnedParticle = Instantiate(ExploParticle, transform.position, transform.rotation);
        //spawnedParticle.transform.parent = transform.root;
        Destroy(spawnedParticle, 5);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius);
        foreach (var nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
            }
        }

        /* Script part from bullet could ba an alternative solution
            public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);

        }
    }
        */


        //hasExploded = true;

        Destroy(gameObject);
    }
}
