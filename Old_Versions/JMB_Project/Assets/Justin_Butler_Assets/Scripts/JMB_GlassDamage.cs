using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_GlassDamage : MonoBehaviour
{
    //////////////////////////////
    // Checklist
    //////////////////////////////

    // I want to check if the player is the object that hit the glass
    // If it is the player, where they fast enough to damage the wall?
    // If they are, I want to hurt them.

    //////////////////////////////
    // Fields
    //////////////////////////////
    
    // I want to be able to change the value in the inspector.
    public int glassDamage = 10;

    //////////////////////////////
    // Collision Events
    //////////////////////////////

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            // I will be referencing these 2 classes.
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            JMB_Destructible_Object jmbDO = GetComponent<JMB_Destructible_Object>();

            if (rb.velocity.magnitude >= jmbDO.speedToDamage)
            {
                Health pHealth = collision.collider.GetComponent<Health>();
                pHealth.ApplyDamage(glassDamage);
            }

        }
    }
}
