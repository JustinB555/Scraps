using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086Medkit : MonoBehaviour
{
    public Health health;
    //Keep a health field for later

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Health health = other.gameObject.GetComponent<Health>(); 
            health.ApplyDamage(-50);
            /* We check for the player tag
             * Find the "Health" game component
             * Apply -50 damage
             * We apply negative damage instead of adding to the current health integer as the ApplyDamage method does that already
             */
            if (health.currentHealth > health.maxHealth)
            {
                health.currentHealth = health.maxHealth;
                /* We check to see if the player health exceed the maximum health
                 * If so, we set the player health back down to max
                 */
            }
            Destroy(this.gameObject);
            //We no longer need this game object, so we throw it away like an unwanted child.
        }
    }

}
