using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTurbine : MonoBehaviour
{
    // GameObject Reference - We will get the animator we want to affect off of this object
    public GameObject animator;

    // Animator Reference
    Animator turbineAnim;

    // Start is called before the first frame update
    void Start()
    {
        turbineAnim = animator.GetComponent<Animator>();
    }

    // This will act as a trigger for any button or switch.
    public void ToggleTurbineAnim()
    {
        // If the bool is already false = off
        if (turbineAnim.GetBool("toggleSpin") == false)
        {
            // We want to set it to true, this will activate the animation
            turbineAnim.SetBool("toggleSpin", true);

            // Here is the message for it
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have activated the Wind Turbine!", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            // If the bool is already true = on
            turbineAnim.SetBool("toggleSpin", false);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have deactivated the Wind Turbine!", SCRAPS_MessageSystem.msgType.standard);
        }
    }
}
