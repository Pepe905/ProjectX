using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToggleScript : MonoBehaviour
{

    public bool oncheckpoint = false;
    public SpriteRenderer initialSprite;
    public SpriteRenderer secondSprite;



    // Start is called before the first frame update
    void Start()
    {
        initialSprite.enabled = true;
        secondSprite.enabled = false;
    }

    // Update is called once per frame

        void OnTriggerEnter2D(Collider2D other)
        {
            // Player
            if (other.gameObject.tag == "Player")
            {
                oncheckpoint = true; 
                Debug.Log("Ashley erreicht einen Checkpoint");
            //Item
                //gameObject.SetActive(false);
            initialSprite.enabled = false;
            secondSprite.enabled = true;
 

            }
            
        }
}
