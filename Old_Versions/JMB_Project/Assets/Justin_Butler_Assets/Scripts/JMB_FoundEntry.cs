using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_FoundEntry : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to see if the player walked into the volume.
    // Check if the objection is complete.
    // If not, send a message and add 1 to the Objective.

    //////////////////////////////
    // Fields
    //////////////////////////////

    // I need to tie this object to the Objective.
    public SCRAPS_Objective obj;

    //////////////////////////////
    // Collision Events
    //////////////////////////////

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (obj.isComplete == false)
            {
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I found a way in!", SCRAPS_MessageSystem.msgType.standard);
                obj.UpdateObjective(1);
            }
        }
    }

}
