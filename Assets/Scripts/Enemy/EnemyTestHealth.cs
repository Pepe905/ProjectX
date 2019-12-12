using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestHealth : MonoBehaviour
{
    public Animator animator;
    public bool dead;
    public float health = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ApplyDamage(float damage)
    {
            print($"enemy health {health} is damaged by {damage}");
        health -= damage;
        if (health <= 0 && animator.GetBool("isDead") == false)
        {
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
            Destroy(transform.parent.gameObject);
        }
    }

    public void Dead()
    {

        Debug.Log("Remove enbeasabwebwtrtbwtbsbtrbnemy:" + gameObject.name);
    }
}
