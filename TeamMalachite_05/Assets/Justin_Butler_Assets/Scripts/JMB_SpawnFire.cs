using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_SpawnFire : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public bool hasVisited = false;
    public bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasVisited == true && hasSpawned == false)
            {
                fire1.SetActive(true);
                fire2.SetActive(true);
                hasSpawned = true;
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "Oh no! The fire is spreading!", SCRAPS_MessageSystem.msgType.standard);
            }
            else if (hasVisited == false)
                hasVisited = true;
        }
    }
}
