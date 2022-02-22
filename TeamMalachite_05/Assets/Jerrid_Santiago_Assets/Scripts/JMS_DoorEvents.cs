using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_DoorEvents : MonoBehaviour
{
    public GameObject DoorObj;
    private AudioSource doorAudio;
    public AudioClip DoorOpen;
    public AudioClip DoorClose;


    // Start is called before the first frame update
    void Start()
    {
        doorAudio = DoorObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayDoorOpen()
    {
        doorAudio.clip = DoorOpen;
        doorAudio.Play();
    }

    void PlayDoorClose()
    {
        doorAudio.clip = DoorClose;
        doorAudio.Play();
    }
}
