using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_ControlDoor : MonoBehaviour
{
    public GameObject animator;
    private Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = animator.GetComponent<Animator>();
        if (doorAnim == null)
        {
            Debug.LogError("No Animator Component Found on " + animator.name);
        }
        else
        {
            Debug.Log("Animator Compnent was Found!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleDoorAnim()
    {
        if (doorAnim.GetBool("toggleDoor") == false)
        {
            doorAnim.SetBool("toggleDoor", true);
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have unlocked the door!", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            doorAnim.SetBool("toggleDoor", false);
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have locked the door!", SCRAPS_MessageSystem.msgType.standard);
        }
    }
}