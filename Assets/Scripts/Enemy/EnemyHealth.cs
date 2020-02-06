using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    public Animator animator;
    public bool dead;
    [SerializeField] float health = 1;
    [SerializeField] private GameObject disappearParticle;
    //[SerializeField] private GameObject disappearParticle2;


    public bool hasDied { get; private set; } = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ApplyDamage(float damage)
    {

        print($"enemy health {health} is damaged by {damage}");
        health -= damage;
        if (health <= 0 && animator.GetBool("isDead") == false)
        {
            hasDied = true;

            print(animator.GetBool("isDead"));

            animator.SetBool("isDead", true);

            print(animator.GetBool("isDead"));

            Debug.Log("Start death animation.");
        }

    }
    private void FixedUpdate()
    {
        if (dead)
        {
            Debug.Log("Remove enemy:" + gameObject.name);
            //Destroy(gameObject);
            Destroy(transform.parent.gameObject, 5);

            GameObject spawnedParticle = Instantiate(disappearParticle, transform.position, transform.rotation);
            //spawnedParticle.transform.parent = transform.root;
            Destroy(spawnedParticle, 5);

            /*Why does the 2nd added particlesystem not do anything?
            GameObject spawnedParticle2 = Instantiate(disappearParticle2, transform.position, transform.rotation);
            //spawnedParticle.transform.parent = transform.root;
            Destroy(spawnedParticle2, 5);
            */
        }
    }

    //here starts the part that should help that the grenade damages/kills the zombie
    public void TakeDamage(int amn)
    {
        Debug.Log("enemy took damage " + amn.ToString());
    }
    //here ends the grenade part

    public void Dead()
    {

        Debug.Log("Remove enbeasabwebwtrtbwtbsbtrbnemy:" + gameObject.name);
    }
}
