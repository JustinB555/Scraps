using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Bridge_Noise : MonoBehaviour
{

    public GameObject BridgeObj;

    private AudioSource bridgeAudio;

    public AudioClip Open;

    private void Start()
    {
        bridgeAudio = BridgeObj.GetComponent<AudioSource>();
        bridgeAudio = GetComponent<AudioSource>();
    }

    void PlaySpin()
    {
        bridgeAudio.clip = Open;
        bridgeAudio.Play();
    }
}