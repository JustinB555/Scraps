using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSnapping : MonoBehaviour
{
    // Game Object for the Static object mesh to be "snapped" in place.
    public GameObject staticObj;

    private void OnTriggerEnter(Collider other)
    {
        // A static object is inside the scene, but is active or not. This is different from "Enable" which adds the object to the scene.
        // I want to know if the staticObj (Front_L_Tire) is active in the scene (grayed out). If it comes back false, then run this code.
        if (staticObj.activeInHierarchy == false)
        {
            // Instead of trying to find a string name, make a script and see if that script is attached to that game object. I like this way because it can be reused and not as much spelling errors.
            if (other.GetComponent<Snap>() != null)
            {
                // Destroy the game object that triggered the event. It would look like the object snapped into place, but it is actually being destroyed and a different object is appearing.
                Destroy(other.gameObject);

                // The staticObj (game object that you assigned staticObj to) is set to render into the scene. Remember that it was already there, but it was not active in the hierarchy (grayed out).
                staticObj.SetActive(true);

                // Call a script that deals with all the messages in the game. Lots of good examples, hit F12 to see more.
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper","I snapped a tire in place!", SCRAPS_MessageSystem.msgType.standard);

                // This game is the game object that the script is attached to (Front_TireTrigger). The "ghost" object will then turn off.
                gameObject.SetActive(false);

                // All of these together will make it seem like the object is snapping.
            }
        }
    }
}
