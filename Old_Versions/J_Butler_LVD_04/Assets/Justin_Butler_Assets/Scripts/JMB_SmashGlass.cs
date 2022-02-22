using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_SmashGlass : MonoBehaviour
{
    public GameObject[] glass;
    public bool resolved;
    public SCRAPS_Objective obj;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < glass.Length; i++)
        {
            JMB_Destructible_Object dO = glass[i].GetComponent<JMB_Destructible_Object>();
            if (dO.objHealth <= 0 && resolved == false)
            {
                obj.UpdateObjective(1);
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I shatter that window!", SCRAPS_MessageSystem.msgType.standard);
                resolved = true;
            }

            /*JMB_Destructible_Object dO = glass[i].GetComponentInChildren<JMB_Destructible_Object>();
            if (dO != null && resolved == false)
            {
                Debug.Log("Glass" + glass[i] + "has the correct script");
                foreach (dO.objHealth <= 0  glass)
                {
                    Debug.Log("Found health");
                    if (obj.isComplete == false)
                    {
                        obj.UpdateObjective(1);
                        SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I shatter that window!", SCRAPS_MessageSystem.msgType.standard);
                        resolved = true;
                    }
                }
            }*/
            //else
                //Debug.Log("Did not find component");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I can probably break those windows if I hit hard enough.", SCRAPS_MessageSystem.msgType.standard);
    }
}
