using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_PowerObjectiveTrigger : MonoBehaviour
{
    [SerializeField]
    private string requiredTagObjective;
    [SerializeField]
    private string requiredMainTagObjective;
    public SCRAPS_Objective obj;
    public SCRAPS_Objective mainObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<JMS_TagSystem>())
        {
            JMS_TagSystem tagSystem = other.GetComponent<JMS_TagSystem>();


            if (tagSystem.jTag2 == requiredTagObjective)
            {
                if (obj.isComplete == false)
                {
                    obj.UpdateObjective(1);
                    //mainObj.UpdateObjective(1);
                }
            }
            if (tagSystem.jTag2 == requiredMainTagObjective)
            {
                if (mainObj.isComplete == false)
                {
                    mainObj.UpdateObjective(1);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<JMS_TagSystem>())
        {
            JMS_TagSystem tagSystem = other.GetComponent<JMS_TagSystem>();


            if (tagSystem.jTag2 == requiredTagObjective)
            {
                if (obj.isComplete == false)
                {
                    obj.UpdateObjective(-1);
                    //mainObj.UpdateObjective(1);
                }
            }
            if (tagSystem.jTag2 == requiredMainTagObjective)
            {
                if (mainObj.isComplete == false)
                {
                    mainObj.UpdateObjective(-1);
                }
            }
        }
    }
}