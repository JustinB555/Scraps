using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086Gate : MonoBehaviour
{

    [SerializeField]
    private int leverRequired = 1;
    /* This integer is the most important of this script
     * We serialize it so we can edit in in editor, no other code should look at this number
     * This code checks if the lever required is 0 or less, if so, we open the gate
     */
    private AudioSource doorSFX;
    public Animator animator;
    public SCRAPS_Objective obj;
    /* We have our audio
     * We get our animator
     * We find the objective system
     */
    private void Start()
    {
        doorSFX = GetComponent<AudioSource>();
        //we get our audio
    }
    public void LeverRaise(int number)
    {
        leverRequired -= number;
        //We lower the leverRequired integer by one
        if (leverRequired <= 0)
            //If our lever required integer is 0 or less (just in case it somehow lowers below 0), we move forward
        {
            if (obj.isComplete == false)
            {
                obj.UpdateObjective(1);
                doorSFX.Play();
                //We play our audio
            }
            animator.SetBool("OpenDoor", true);
            /*We check to see if we already completed the objective, if not, we update the objective by 1
             * We then open the door using our animation and get out of this if statement
             */
        }
    }
}
