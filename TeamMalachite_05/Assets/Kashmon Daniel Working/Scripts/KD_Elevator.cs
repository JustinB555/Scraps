﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Elevator : MonoBehaviour
{
    public GameObject animator;

    private Animator anim;

    private void Start()
    {
        anim = animator.GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("No Animator Component Found on" + animator.name);
        }
        else
        {
            Debug.Log("Animator Component was Found!");
        }
    }

    public void Elevate()
    {
        if (anim.GetBool("lever") == false)
        {
            anim.SetBool("lever", true);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper","The elevator just came up", SCRAPS_MessageSystem.msgType.standard);
        }
        else
        {
            anim.SetBool("lever", false);

            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "nothing", SCRAPS_MessageSystem.msgType.standard);

        }
    }
}