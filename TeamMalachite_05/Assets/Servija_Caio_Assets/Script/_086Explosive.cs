using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086Explosive : MonoBehaviour
{
    public GameObject broken; //Broken Barricade
    public GameObject notbroken; //Regular Barricade
    public SCRAPS_Objective obj;
    public GameObject ghost;
    public GameObject bombOff;
    public GameObject bombOn;
    public bool armed = false;
    public ParticleSystem explosion;
    private bool DontSpeakTwice = false;
    private AudioSource bombSFX;
    /* We get our broken barricade
     * we get our regular barricade
     * we get our objectives system
     * we get our ghost bomb
     * we get our disabled bomb
     * we get our enabled bomb
     * we set the bomb's armed status to false
     * we get our particle system, name it explosion
     * DontSpeakTwice is a fix to a bug we had early on where the scrapper didn't shut up
     */

    private void Start()
    {
        bombSFX = GetComponent<AudioSource>();
        //we get our explosive audio
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == bombOff)
        {
            Destroy(bombOff);
            Destroy(ghost);
            bombOn.SetActive(true);
            armed = true;
            /* If the disabled bomb touches our ghost bomb
             * we destroy our disabled bomb
             * we destroy our ghost bomb
             * we enable our armed bomb
             * we set the armed status to true to match this
             */
        }
    }
    public void Explode()
    {
        if (!armed)
        {
            return;
            //If the bomb ain't armed, we gtfo
        }
        if (!DontSpeakTwice)
        {
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "That barricade is gone now!", SCRAPS_MessageSystem.msgType.standard);
            DontSpeakTwice = true;
            /* We have the scrapper tell the player they broke the barricade
             * But only once
             * We only run this if DontSpeakTwice is its initial value of false
             */
            Break();
            bombSFX.Play();
            explosion.Play();
            Destroy(bombOn);
            Debug.Log("We should have destroyed the bomb");
            Destroy(this.gameObject, 5.0f);
            /* We invoke break
             * play our explosion particle
             * We commit sudoku in 5 seconds.
             */
        }
    }
    private void Break()
    {
        broken.SetActive(true);
        notbroken.SetActive(false);
        //We set the broken barricade to true, and the fixed one to false
        if(obj.isComplete == false)
        {
            obj.UpdateObjective(1);
            //If the objective ain't complete, we ding it by one.
        }
    }
}
