using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_InteractDoc : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to check to see if this is still alive.
    // 1) If not, update Objective.
    // 2) If yes, do nothing.
    // 3) Guide the player to the exit.

    //////////////////////////////
    // Fields
    //////////////////////////////

    // I want to see all my GameObjects.
    public GameObject[] docs;
    // I need to prevent it from continously checking it.
    public bool[] hasChecked;
    // Same thing as above.
    public bool isAsleep = true;
    // I need to keep track of our Objective.
    public SCRAPS_Objective obj;
    // This GameObject is sleeping, until I wake it up.
    public GameObject sleep;

    //////////////////////////////
    // Ticks
    //////////////////////////////

    // Counts 1 ever frame
    private void Update()
    {
        for (int i = 0; i < docs.Length; i++)
        {
            if (hasChecked[i] == false)
            {
                if (docs[i] == null)
                {
                    SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I found 1 of the documents!", SCRAPS_MessageSystem.msgType.standard);
                    obj.UpdateObjective(1);
                    hasChecked[i] = true;
                }
            }
        }

        if (obj.isComplete == true && isAsleep == true)
        {
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "Time to leave. Where is that exit?", SCRAPS_MessageSystem.msgType.standard);
            sleep.SetActive(true);
            isAsleep = false;
        }
    }

}
