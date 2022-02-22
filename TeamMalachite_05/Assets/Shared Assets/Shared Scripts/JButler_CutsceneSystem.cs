using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JButler_CutsceneSystem : MonoBehaviour
{
    //////////////////////////////
    // Fields
    //////////////////////////////

    // We want to create a nickname for the Player's Camera.
    public GameObject playerCam;
    // Same for the Cutscene's Camera.
    public GameObject cutCam;
    // We will also need a nickname for the Cutscene's Animator.
    private Animator cutAnim;
    // The player can't have any control, so we must lock them. This is a check for that.
    private bool lockPlayer = false;
    // We will need to speak to the Player's Transform too.
    public Transform thePlayer;
    // Nickname for the last saved position
    public Vector3 lastPos = Vector3.zero;
    public Vector3 newPos;
    // I need the end vehicle to appear when called.
    public GameObject endVeh;

    //////////////////////////////
    // Ticks
    //////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        // Make a shortcut/nickname for our Animator.
        cutAnim = GetComponent<Animator>();
        // Disable the Cutscene's Camera till triggered.
        cutCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // We want to lock the Player's position durning the cutscene.
        if (lockPlayer == true)
        {
            // If we know where the Player is.
            if (thePlayer != null)
            {
                // Set the Player where they were until we say otherwise.
                thePlayer.position = lastPos;
            }
        }
    }

    //////////////////////////////
    // Buttons
    //////////////////////////////

    // When we interact and start our cutscene.
    public void StartCutscene()
    {
        // Disable the Player's Camera.
        playerCam.SetActive(false);
        // Hold the Player's position.
        lockPlayer = true;

        // Trigger the Cutscene animation!
        cutAnim.SetTrigger("startTheShow");
        cutAnim.SetTrigger("endTheShow");
    }

    // When the cutscene finishes.
    public void StopCutscene()
    {
        // Set the Player's new position.
        thePlayer.position = newPos;
        //Enable the Player's Camera.
        playerCam.SetActive(true);
        //Disable the Cutscene's Camera.
        cutCam.SetActive(false);
        // Allow the Player to move again.
        lockPlayer = false;
        endVeh.SetActive(true);

    }
}
