using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosionSpriteScript : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isExploding", true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}