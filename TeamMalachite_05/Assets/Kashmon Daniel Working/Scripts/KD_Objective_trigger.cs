using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KD_Objective_trigger : MonoBehaviour
{
    public SCRAPS_Objective obj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("the player has entered the trigger volume!");

            if(obj.isComplete == false)
            {
                obj.UpdateObjective(1);
            }
        }
    }
}  
