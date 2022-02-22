using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Door_Chime: MonoBehaviour
{
    
    public GameObject DoorObj;

    private AudioSource doorAudio;

    public AudioClip Open;
    public AudioClip Close;

    private void Start()
    {
        doorAudio = DoorObj.GetComponent<AudioSource>();
        doorAudio = GetComponent<AudioSource>();
    }

    void PlayOpen()
    {
        doorAudio.clip = Open;
        doorAudio.Play();
    }

    void PlayClose()
    {
        doorAudio.clip = Close;

        doorAudio.Play();


    }
}
