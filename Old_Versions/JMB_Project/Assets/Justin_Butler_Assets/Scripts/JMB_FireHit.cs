using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_FireHit : MonoBehaviour
{
    public GameObject fire;
    public GameObject puff;
    public bool fireIsOut = false;

    private void Update()
    {
        if (fire.activeInHierarchy == false && fireIsOut == false)
        {
            puff.SetActive(true);
            Invoke("StopPartical", 1.0f);
            fireIsOut = true;
        }
    }

    void StopPartical()
    {
        puff.SetActive(false);
    }
}
