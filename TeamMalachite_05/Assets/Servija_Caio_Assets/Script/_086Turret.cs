using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086Turret : MonoBehaviour
{
    public GameObject barrel;
    public GameObject pivot;
    public GameObject detonator;
    public GameObject scrapper;
    public Health health;
    private Ray origin;
    private RaycastHit hit;
    private GameObject target;
    public bool canShoot = true;
    public _086Explosive explosive;
    private AudioSource bang;
    public ParticleSystem muzzleFlash;
    /* We get our barrel object, to orient our shots
     * pivot object (which I don't think we need) TODO: delete it
     * detonator, being the active bomb
     * health stored for later
     * We dont even use origin now, it can go TODO: delete it as well
     * raycast hit is what we hit with out bullet so to speak
     * canShoot controls your fire-rate
     * explosive is the script which destroys the barrier
     * bang is the gunshot
     * muzzleFlash is our muzzle flash obviously
     */

    private void Start()
    {
        bang = GetComponent<AudioSource>();
        //we get our gunshot audio
    }

    void Update()
    {
        Physics.Raycast(barrel.transform.position, barrel.transform.up * 5, 10);
        //Debug.DrawRay(barrel.transform.position, barrel.transform.up * 5, Color.white);
        if (Physics.Raycast(barrel.transform.position, barrel.transform.up * 5, out hit, 10))
            /* We set up our glorious raycast, and orient it to fire properly
             * The debug is just there for debugging purposes, commented out for optimization
             * we output what the raycast collided with through hit
             */
        {
            target = hit.collider.gameObject;
            if (target.tag == "Player" & canShoot)
            {
                Health pHealth = target.GetComponent<Health>();
                pHealth.ApplyDamage(Random.Range(4,18));
                bang.Play();
                muzzleFlash.Play();
                canShoot = false;
                Invoke("UnlockShot", 0.5f);
                /* *inhale*
                 * We get the gameobject of our hit through its collider
                 * If the target's tag is "Player" and canShoot is true, we can shoot, and move on
                 * we get the health component of our target, and name it pHealth
                 * we invoke the ApplyDamage method from the player's health script, and deal between 1 and 5 damage, this was 3 to 6 earlier, but that killed too quickly
                 * People complained the damage was low, it is now higher than it was originally.
                 * We play our gunshot, so the player gets an audible confirmation that the turret has fired
                 * We set canShoot to false, so that the player does not take damage every frame
                 * we invoke the unlock shot method, which sets canShoot back to true, in half a second
                 * Fun fact: this turret has a fire rate of 120rpm
                 * *exhale*
                 * and we are done here
                 */
            }
            if (target == detonator)
            {
                explosive.Explode();
                /*we invoke the explode method from explosive
                 */
            }
        }
    }


    void UnlockShot()
    {
        canShoot = true;
    }
}
