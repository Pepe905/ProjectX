using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteExchangeScript : MonoBehaviour
{

    public int itemType;
    public bool checkpointActive = false;
    public SpriteRenderer targetSprite;
    


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
                checkpointActive = true; 
                Debug.Log("Checkpoint activated by player");
            //Item
                gameObject.SetActive(false);
                



            }
            
        }
    
}
