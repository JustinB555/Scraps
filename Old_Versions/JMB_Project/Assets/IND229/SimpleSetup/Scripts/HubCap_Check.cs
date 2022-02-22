using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCap_Check : MonoBehaviour
{
    // Game Object for the Hub Cap Mesh.
    public GameObject HubCap;

    // 
    public GameObject GB_HubCap;

    // This method will be what we call with "On Interact()".
    public void AttachHubCap()
    {
        // Do we have a "Hub Cap" inside our inventory? I thought it was the name of the gameObject, but it is instead the name of the "Key Item Name".
        if (SCRAPS_Inventory.instance.CanConsumeKeyItem("Hub Cap", 1))
        {
            // Same as the ObjSnapping script. You have a stactic object that is inactive until you activate it.
            HubCap.SetActive(true);

            //
            GB_HubCap.SetActive(false);

            // Send a message to the console/UI.
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I snapped a hub cap in place", SCRAPS_MessageSystem.msgType.standard);

            // Disable the interactive ability of this object (Front_L_Tire). Now we can't keep putting more objects into this tire.
            gameObject.GetComponent<SCRAPS_Interactive>().enabled = false;
        }
        else
        {
            // What we tell the player when they don't have the item correct item with them.
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "There must be a hub cap around here...", SCRAPS_MessageSystem.msgType.standard);
        }
    }
}
