using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollection : MonoBehaviour
{


    public bool collect = false;
<<<<<<< HEAD
    Trophyscript ontrophy;  
    
    // Start is called before the first frame update
    void Start()
    {
        ontrophy = GameObject.FindGameObjectWithTag("Item").GetComponent<Trophyscript>();
=======
    Trophyscript trophy;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trophy = GameObject.FindGameObjectWithTag("Item").GetComponent<Trophyscript>();
>>>>>>> Initial Commit
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (ontrophy) 
        {
            
            gameObject.SetActive(true);
=======
        if (trophy.ontrophy) 
        {

            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.spriteRenderer.enabled = true;
>>>>>>> Initial Commit
        }
    }
}
