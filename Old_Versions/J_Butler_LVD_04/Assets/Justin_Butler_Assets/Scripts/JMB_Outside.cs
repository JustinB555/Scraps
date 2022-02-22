using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_Outside : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to check if the Player has all the documents.
    // If yes, finish level.

    //////////////////////////////
    // Fields
    //////////////////////////////

    // I need to talk with the Objectives.
    public SCRAPS_Objective obj1;
    public SCRAPS_Objective obj2;

    //////////////////////////////
    // Collision Events
    //////////////////////////////

    // Trigger when I walk through it.
    // Remember I need to check to see if they have the 1st objective completed before completing the 2nd.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (obj1.isComplete == true)
            {
                if (obj2.isComplete == false)
                {
                    obj2.UpdateObjective(1);
                    SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "Now I can get out of here.", SCRAPS_MessageSystem.msgType.standard);
                }
            }
            else
            {
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I am still missing some documents, better go find them first", SCRAPS_MessageSystem.msgType.standard);
            }
        }
    }
}
