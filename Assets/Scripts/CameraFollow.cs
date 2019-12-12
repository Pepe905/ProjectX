using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float CameraBorderX;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player && player.transform.position.x > CameraBorderX)
        transform.position = new Vector3(player.transform.position.x, transform.position.y , transform.position.z);
    }
}
