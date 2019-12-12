using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestHealth : MonoBehaviour
{
    public Animator animator;
    public bool dead;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float health = 1;
    void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && animator.GetBool("isDead") == false)
            animator.SetBool("isDead", true);

    }
    private void FixedUpdate()
    {
        if (dead)
        {
            Destroy(gameObject);
        }
    }

}
