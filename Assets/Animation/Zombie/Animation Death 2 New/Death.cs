using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isDead", true);
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
