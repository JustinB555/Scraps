using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Collect : MonoBehaviour
{

    public string msgFrom;
    public string msgBody;
    public void ShowMyMessage()
    {
        SCRAPS_MessageSystem.instance.NewMessage(msgFrom, msgBody, SCRAPS_MessageSystem.msgType.standard);
    }
}
