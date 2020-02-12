using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophyscript : MonoBehaviour
{

    public int itemType;
    public bool ontrophy = false;
    public Transform targetTransform;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


        void OnTriggerEnter2D(Collider2D other)
        {
            // Player
            if (other.gameObject.tag == "Player")
            {
                ontrophy = true;
                Debug.Log("Hallo");
            //Item
                gameObject.SetActive(false);
                



            }
            
        }
    
}
