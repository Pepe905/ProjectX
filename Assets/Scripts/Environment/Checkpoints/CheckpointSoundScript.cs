using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSoundScript : MonoBehaviour {
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter()
    {
        audio.PlayOneShot(SoundToPlay, Volume);
        alreadyPlayed = true;
    }

}
