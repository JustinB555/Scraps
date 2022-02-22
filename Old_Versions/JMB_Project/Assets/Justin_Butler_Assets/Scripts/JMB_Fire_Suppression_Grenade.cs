using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_Fire_Suppression_Grenade : MonoBehaviour
{
    // Fields
    public AudioClip explode;
    public AudioClip thud;
    public AudioSource audioCrate;

    // Start is called before the first frame update
    void Awake()
    {
        audioCrate = GameObject.Find("FSG_Crate").GetComponent<AudioSource>();
    }

    // I need a way to turn off the object.
    private void OnTriggerEnter(Collider other)
    {
        // If the object that hit the fire is a FSG, then it will explode.
        if (other.GetComponent<JMB_FSG>() != null)
        {
            //Debug.Log("Hitting Trigger");
            audioCrate.clip = explode;
            audioCrate.Play();
            // Both the fire and the FSG will turn off.
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            Invoke("StopSound", 1.0f);
        }
        else
        {
            Debug.Log("You hit something else named" + other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //audioCrate.clip = thud;
        //audioCrate.Play();
    }

    void StopSound()
    {
        audioCrate.Stop();
    }
}
