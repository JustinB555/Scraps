using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JButler_CutsceneTrigger : MonoBehaviour
{
    //////////////////////////////
    // Fields
    //////////////////////////////

    // We need a reference to our Cutscene System.
    public JButler_CutsceneSystem cutSys;

    //////////////////////////////
    // Collision Events
    //////////////////////////////

    private void OnTriggerEnter(Collider other)
    {
        // We need to check if the Player was the one to trigger this event.
        if (other.tag == "Player")
        {
            // It is the Player, tell the Cutscene System.
            cutSys.thePlayer = other.transform;
            // Locate the Player's Camera and save it.
            cutSys.playerCam = GameObject.FindWithTag("MainCamera");
            // Save the Player's position in the Cutscene System.
            cutSys.lastPos = other.transform.position;
            // Enable the Cutscene's Camera.
            cutSys.cutCam.SetActive(true);
            // Start the Cutscene!
            cutSys.StartCutscene();
            // This shouldn't trigger again. Kill the trigger object!
            Destroy(gameObject);
        }
    }
}
