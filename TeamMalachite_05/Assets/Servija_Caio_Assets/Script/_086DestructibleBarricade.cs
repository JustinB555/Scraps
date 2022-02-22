using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086DestructibleBarricade : MonoBehaviour
{
    public GameObject broken;
    public GameObject notbroken;
    /* We get our broken state
     * We get our fixed state
     */

    public void Break()
    {
        broken.SetActive(true);
        notbroken.SetActive(false);
        //We make the object broken
    }
}
