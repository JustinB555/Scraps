﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_CloseToDoc : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to let the player know when they are getting close to a document.

    //////////////////////////////
    // Collision Event
    //////////////////////////////

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I think I am close to a <b>Document</b>", SCRAPS_MessageSystem.msgType.standard);
    }
}