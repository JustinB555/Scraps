using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    AudioSource doorAudio;
    public AudioClip openDoor;
    public AudioClip closDoor;

    // Start is called before the first frame update
    void Start()
    {
        doorAudio = GetComponent<AudioSource>();
    }

    void PlayOpen()
    {
        doorAudio.clip = openDoor;
        doorAudio.Play();
    }

    void PlayClose()
    {
        doorAudio.clip = closDoor;
        doorAudio.Play();
    }
}
