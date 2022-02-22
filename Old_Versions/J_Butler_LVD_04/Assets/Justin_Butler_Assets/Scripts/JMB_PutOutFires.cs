using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_PutOutFires : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public SCRAPS_Objective obj;
    public bool checkedFire1 = false;
    public bool checkedFire2 = false;

    // Update is called once per frame
    void Update()
    {
        if (fire1.activeInHierarchy == false && checkedFire1 == false)
        {
            obj.UpdateObjective(1);
            checkedFire1 = true;
        }
        if (fire2.activeInHierarchy == false  && checkedFire2 == false)
        {
            obj.UpdateObjective(1);
            checkedFire2 = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "I need to put out these fires before I can go forward.", SCRAPS_MessageSystem.msgType.standard);
    }
}
