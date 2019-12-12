using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestHealth : MonoBehaviour
{
    public float health = 1;
    void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }

}
