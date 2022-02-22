using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_ControlBars : MonoBehaviour
{
    public GameObject animator;
    private Animator barsAnim;
    // Start is called before the first frame update
    void Start()
    {
        barsAnim = animator.GetComponent<Animator>();
        if (barsAnim == null)
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

    public void ToggleBarsAnim()
    {
        if (barsAnim.GetBool("toggleBars") == false)
        {
            barsAnim.SetBool("toggleBars", true);
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have deactivated the Security!", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            barsAnim.SetBool("toggleBars", false);
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I have reactivated the Security!", SCRAPS_MessageSystem.msgType.standard);
        }
    }
}
