using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapHandle : MonoBehaviour
{
    public GameObject staticObj;
    public GameObject myParent;

    private void OnTriggerEnter(Collider other)
    {
        if (staticObj.activeInHierarchy == false)
        {
            if (other.GetComponent<Snap>() != null)
            {
                Destroy(other.gameObject);
                staticObj.SetActive(true);
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I attached the handle to the door!", SCRAPS_MessageSystem.msgType.standard);
                myParent.SetActive(false);
            }
        }
    }
}
