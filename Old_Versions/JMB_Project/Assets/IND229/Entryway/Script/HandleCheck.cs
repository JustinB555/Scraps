using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCheck : MonoBehaviour
{
    public GameObject animator;
    public GameObject doorHandle;
    Animator doorAnim;

    private void Start()
    {
        doorAnim = animator.GetComponent<Animator>();
    }

    public void ToggleDoorAnim()
    {
        if (doorHandle.activeInHierarchy == true)
        {
            if (doorAnim.GetBool("toggleOpen") == false)
            {
                doorAnim.SetBool("toggleOpen", true);
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I openned the door!", SCRAPS_MessageSystem.msgType.standard);
            }
            else
            {
                doorAnim.SetBool("toggleOpen", false);
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I closed the door.", SCRAPS_MessageSystem.msgType.standard);
            }
        }
        else
        {
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I am missing the handle?!", SCRAPS_MessageSystem.msgType.standard);
        }

    }
}
