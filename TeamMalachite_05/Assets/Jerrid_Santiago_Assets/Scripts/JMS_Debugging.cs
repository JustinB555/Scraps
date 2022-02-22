using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_Debugging : MonoBehaviour
{

    [SerializeField]
    private bool enableDebugMessages = true;

    public void DebugMessage(string msg)
    {
        if (enableDebugMessages == true)
        {
            Debug.Log(msg);
            SCRAPS_MessageSystem.instance.NewMessage("debug", msg, SCRAPS_MessageSystem.msgType.system);
        }
    }
}
