using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{ 

    public float climbspeed;
    float climbVelocity;
    Rigidbody2D playerRB;
    public bool onLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

        
    {
        if(onLadder)
        {
            climbVelocity = climbspeed * Input.GetAxisRaw("Vertical");
            playerRB.velocity = new Vector2(0, climbVelocity);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player
        if (other.gameObject.tag == "Player")
        {
            onLadder = true;
            Debug.Log("Ashley erreicht Leiter im Haus");
         //Gravitation
            playerRB.gravityScale = 0f;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player
        if (other.gameObject.tag == "Player")
        {
            onLadder = false;
            Debug.Log("Ashley verlässt Leiter im Haus");
            //Gravitation
            playerRB.gravityScale = 1.6f;
        }
    }


}
