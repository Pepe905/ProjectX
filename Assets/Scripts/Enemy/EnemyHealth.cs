using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private GameObject deathAnimation;
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
            //Instantate the Animation
            Instantiate(deathAnimation, transform.position, transform.rotation);
            Destroy(gameObject);
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
