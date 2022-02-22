using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Lever_Control: MonoBehaviour
{
    public GameObject animator;

    private Animator plate_anim;

    private void Start()
    {
        plate_anim = animator.GetComponent<Animator>();

        if (plate_anim == null)
        {
            Debug.LogError("No Animator Component Found on" + animator.name);
        }
        else
        {
            Debug.Log("Animator Component was Found!");
        }
    }

    public void TogglePlate()
    {
        if (plate_anim.GetBool("Lever") == false)
        {
            plate_anim.SetBool("Lever", true);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "Oh, the plate pulled out!", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            plate_anim.SetBool("Lever", false);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "The plate closed", SCRAPS_MessageSystem.msgType.standard);

        }
    }
}

