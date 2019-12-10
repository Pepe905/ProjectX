using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollection : MonoBehaviour
{


    public bool collect = false;
    Trophyscript trophy;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trophy = GameObject.FindGameObjectWithTag("Item").GetComponent<Trophyscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trophy.ontrophy) 
        {

            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.spriteRenderer.enabled = true;
        }
    }
}
