using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollection : MonoBehaviour
{


    public bool collect = false;
    Trophyscript ontrophy;  
    
    // Start is called before the first frame update
    void Start()
    {
        ontrophy = GameObject.FindGameObjectWithTag("Item").GetComponent<Trophyscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ontrophy) 
        {
            
            gameObject.SetActive(true);
        }
    }
}
