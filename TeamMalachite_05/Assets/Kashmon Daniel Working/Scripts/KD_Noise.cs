using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Noise : MonoBehaviour
{
    public GameObject PlateObj;

    private AudioSource plateAudio;

    public AudioClip Open;
    public AudioClip Close;

    private void Start()
    {
        plateAudio = PlateObj.GetComponent<AudioSource>();
        plateAudio = GetComponent<AudioSource>();
    }

    void PlayOpen()
    {
        plateAudio.clip = Open;
        plateAudio.Play();
    }

    void PlayClose()
    {
        plateAudio.clip = Close;

        plateAudio.Play();


    }
}