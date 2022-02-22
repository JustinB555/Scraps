using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_FoundExit : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to tell the player that they found the Exit.

    //////////////////////////////
    // Fields
    //////////////////////////////

    // I need to speak to the Objective.
    public SCRAPS_Objective obj;
    // Do it only once.
    public bool hasChecked = false;

    //////////////////////////////
    // Collision Event
    //////////////////////////////

    // Trigger when I walk into it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && hasChecked == false)
        {
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "That looks like an <b>Exit</b>.", SCRAPS_MessageSystem.msgType.standard);
            obj.UpdateObjective(1);
            hasChecked = true;
        }
    }
}
