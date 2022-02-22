using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_Destructible_Object : MonoBehaviour
{
    // Checklist

    // We have multiple stages
    // Stages subtract on collision (health)
    // Remove collision on this object when stage 0 is reached
    // Make sure the object is traveling fast enough to damage the wall

    // Fields

    // We are going to be referencing the BoxCollider component in Unity.
    public BoxCollider bCollider;
    // By using an array, we can have multiple stages.
    // Arrays go from 0,1,2,...
    public GameObject[] stages;
    // How much "Health" does the object have.
    public int objHealth = 2;
    // An object needs a strong enough impact to damage the object.
    public float speedToDamage = 3.0f;

    // Counts every frame.
    private void Update()
    {
        // starts at 0; check to see if i is less then the stages' length; and add 1
        for (int i = 0; i < stages.Length; i++)
        {
            // Check to see if the current stage is equal to the current health.
            if (i == objHealth)
            {
                // If it is, then it will stay active.
                stages[i].SetActive(true);
            }
            else
            {
                // If it isn't, it will turn off.
                stages[i].SetActive(false);
            }
        }

        // No more collision... WE DEAD
        if (objHealth <= 0)
        {
            // Turn off the Box Collider.
            if (bCollider.enabled == true)
                bCollider.enabled = false;
        }
    }

    // Ouch!!!
    private void OnCollisionEnter(Collision collision)
    {
        // Does the object that hit us have a Rigidbody component?
        if (collision.collider.GetComponent<Rigidbody>() != null)
        {
            // Make ourselves a varible for Rigidbody.
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            // Was the object fast enough to hurt us?
            if (rb.velocity.magnitude >= speedToDamage)
            {
                // YEP! OUCH!!
                objHealth--;

                // Clamp the health to 0.
                if (objHealth < 0)
                {
                    objHealth = 0;
                }
            }
        }
    }
}
