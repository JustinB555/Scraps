using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Door_Control: MonoBehaviour
{
    public GameObject animator;

    private Animator dooranim;

    private void Start()
    {
        dooranim = animator.GetComponent<Animator>();

        if (dooranim == null)
        {
            Debug.LogError("No Animator Component Found on" +animator.name);
        }
        else
        {
            Debug.Log("Animator Component was Found!");
        }
    }

    public void OpenDoor()
    {
        if (dooranim.GetBool("Door") == false)
        {
            dooranim.SetBool("Door", true);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I opened the door", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            dooranim.SetBool("Door", false);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "The door closed", SCRAPS_MessageSystem.msgType.standard);

        }
    }
}

