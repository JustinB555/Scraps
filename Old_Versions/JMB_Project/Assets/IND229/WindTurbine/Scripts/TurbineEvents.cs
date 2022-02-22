using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineEvents : MonoBehaviour
{
    // 
    public GameObject turbineObj;

    // 
    AudioSource turbineAudio;
    AudioSource stalkAudio;

    // 
    public AudioClip liftUp;
    public AudioClip liftDown;

    // Start is called before the first frame update
    void Start()
    {
        // I will need the Audio Source from the Turbine
        turbineAudio = turbineObj.GetComponent<AudioSource>();
        stalkAudio = GetComponent<AudioSource>();
    }

    void PlayLiftUp()
    {
        // Set the Audio Clip to LiftUp
        stalkAudio.clip = liftUp;
        // Play the Audio Clip
        stalkAudio.Play();
    }

    void PlayLiftDown()
    {
        // Set the Audio Clip to LiftDown
        stalkAudio.clip = liftDown;
        // Play the Audio Clip
        stalkAudio.Play();
        // Stop the wind
        turbineAudio.Stop();
    }

    void PlayWindAudio()
    {
        // Start playing the wind
        turbineAudio.Play();
    }
}
