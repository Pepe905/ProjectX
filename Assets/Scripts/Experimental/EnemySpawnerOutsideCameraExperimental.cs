using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOutsideCameraExperimental : MonoBehaviour {
    private int waveNumber = 2;
    public int enemiesAmount = 2;
    public GameObject zombie;
    public Camera cam;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        enemiesAmount = 2;
    }

// Update is called once per frame
void Update () {
        //float height = cam.orthographicSize; // now zombies spawn od camera view border
		float height = cam.orthographicSize + 1; // now they spawn just outside
        float width = cam.orthographicSize * cam.aspect + 1;
        if (enemiesAmount==0) {
            waveNumber++;
            for (int i = 0; i < waveNumber; i++) {
                Instantiate(zombie, new Vector3(cam.transform.position.x + Random.Range(-width, width),3,cam.transform.position.z+height+Random.Range(10,30)),Quaternion.identity);
                enemiesAmount++;
            }
        }
    }
}