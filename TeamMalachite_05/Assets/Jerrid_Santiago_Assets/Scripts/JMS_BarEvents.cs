using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_BarEvents : MonoBehaviour
{
    public GameObject BarObj;
    private AudioSource barAudio;
    public AudioClip BarOpen;
    public AudioClip BarClose;


    // Start is called before the first frame update
    void Start()
    {
        barAudio = BarObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayBarOpen()
    {
        barAudio.clip = BarOpen;
        barAudio.Play();
    }

    void PlayBarClose()
    {
        barAudio.clip = BarClose;
        barAudio.Play();
    }

}
