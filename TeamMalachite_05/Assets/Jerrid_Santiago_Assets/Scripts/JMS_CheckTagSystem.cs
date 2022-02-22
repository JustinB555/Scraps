using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMS_CheckTagSystem : MonoBehaviour
{

    [SerializeField]
    private string requiredTag;
    //[SerializeField]
    //private string requiredTagObjective;
    //[SerializeField]
    //private string requiredMainTagObjective;
    public AudioClip audioClip;
    //public SCRAPS_Objective obj;
    //public SCRAPS_Objective mainObj;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<JMS_TagSystem>())
        {
            JMS_TagSystem tagSystem = collision.collider.GetComponent<JMS_TagSystem>();

            if (tagSystem.jTag == requiredTag)
            {
                SCRAPS_MessageSystem.instance.NewMessage("Scrapper", "The glass has shattered, you can now enter!", SCRAPS_MessageSystem.msgType.standard);
                DestroyObject();
            }
            /*if (tagSystem.jTag2 == "trigger")
            {
                if (obj.isComplete == false)
                {
                    obj.UpdateObjective(1);
                    //mainObj.UpdateObjective(1);
                }
            }
            /*else if (tagSystem.jTag == requiredMainTagObjective)
            {
                if (mainObj.isComplete == false)
                {
                    obj.UpdateObjective(1);
                }
            }*/
        }

        void DestroyObject()
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(gameObject);
        }
    }
}