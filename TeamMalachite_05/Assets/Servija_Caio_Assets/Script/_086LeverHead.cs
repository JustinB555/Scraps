using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _086LeverHead : MonoBehaviour
{
    private Transform trans;
    private Rigidbody rigid;
    /*Standard stuff
     * we get our transform
     * we get our rigidbody
     */

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        trans = this.GetComponent<Transform>();
        /* more standard stuff
         * We initialize our transform
         * We initalize our rigidbody
         */
    }
    public void Stop()
    {
        rigid.isKinematic = true;
        //When this method is invoked, we turn off kinematic, freezing the object in place
    }

    public void Resume()
    {
        rigid.isKinematic = false;
        //When this method is invoked, we turn kinematic back on, causing the object to now move
    }
}
