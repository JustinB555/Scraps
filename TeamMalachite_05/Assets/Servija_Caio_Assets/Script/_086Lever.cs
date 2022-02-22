using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086Lever : MonoBehaviour
{

    public GameObject broken;
    public GameObject notBroken;
    public GameObject lever;
    public _086LeverHead leverScript;
    private bool canTrig = true;
    public _086Gate gate;
    public Animator leverAnim;
    private AudioSource leverSFX;
    /* we get the variant of this switch without the lever head
     * we get the variant of this switch with the lever head
     * we get the lever head
     * we get the lever head's script
     * canTrig determines if we can use the lever 
     * we get the gate
     * we get our animator
     * We get our lever SFX
     */
    private void Start()
    {
        leverSFX = GetComponent<AudioSource>();
        //we get our lever audio
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("something is in the trigger");
        if (other.gameObject == lever & canTrig)
            //We move forward only if the lever is in the trigger AND we have not run this script
        {
            //Debug.Log("Lever is working");
            leverScript.Stop();
            broken.SetActive(false);
            notBroken.SetActive(true);
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "That lever is on now! I wonder if it can come off again?", SCRAPS_MessageSystem.msgType.standard);
            leverSFX.Play();
            lever.SetActive(false);
            canTrig = false;
            gate.LeverRaise(1);
            leverAnim.SetBool("LeverOn", true);
            /* *inhale*
             * We stop the lever from moving by invoking its stop method
             * we hide our broken switch
             * we enable our fixed switch
             * we have the scrapper hint the player at what they can do next
             * We play the audio
             * we hide the leverhead
             * we turn off cantrig so we never run this again
             * we invoke the leverraise method from our gate
             * we turn on our animation bool to play our lever animation
             * *exhale*
             * We are done here
             */
        }
    }

    public void Resume()
    {
        lever.SetActive(true);
        leverScript.Resume();
        broken.SetActive(true);
        notBroken.SetActive(false);
        SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I wonder if I can use this elsewhere?", SCRAPS_MessageSystem.msgType.standard);
        /* We reveal the lever head
         * We resume lever movement
         * we turn on the broken switch
         * we hide our fixed switch
         * We remind or hint the player that the lever head is still of use
         */
    }
}
