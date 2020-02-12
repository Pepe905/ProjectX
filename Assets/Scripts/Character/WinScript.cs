using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public int itemType;
    public bool onLiev = false;
    public Transform targetTransform;
    public string Scene;

    public void SwitchScene()

    {
        SceneManager.LoadScene(Scene);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player
        if (other.gameObject.tag == "Player")
        {
            onLiev = true;
            SceneManager.LoadScene(Scene);

        }

        
        
    }
}