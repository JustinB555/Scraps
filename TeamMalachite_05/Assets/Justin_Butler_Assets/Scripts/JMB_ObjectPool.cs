using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMB_ObjectPool : MonoBehaviour
{
    #region Singularity
    // Singularity, a simple one. I don't want anyone touching this.
    public static JMB_ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Fields
    // List is a Generic code; List<T>.
    public List<GameObject> pooledObjects;
    // This will allow me to choose whatever GameObject I want to make a pool of.
    public GameObject objectToPool;
    // I can determine how many objects I want to pool.
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        // If I am using multiple differnt pooled objects, I can't have them being mixed up.
        pooledObjects = new List<GameObject>();
        // This will keep track of how many GameObjects there are the world, and if it needs to add any more.
        for (int i = 0; i < amountToPool; i++)
        {
            // Creating a shorter variable.
            // This will create the new GameObject that is the copy/duplicate of our reference/prefab/GameObject.
            GameObject obj = (GameObject)Instantiate(objectToPool);
            // Turning it off until it is called.
            obj.SetActive(false);
            // Adds to the List. Each GameObject adds to the List's count, increasing it by 1.
            pooledObjects.Add(obj);
        }
    }

    // Don't need Update for this code.

    // I need a way to get the object from the pool now.
    public GameObject GetObjectFromPool()
    {
        // Because the List's length is set previously, we call it back again.
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // Is the current GameObject we are calling active? ture = false = return null; false = true = return with the GameObject.
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // I want the Raycast to hit the collider, but I don't want other objects hitting it too.
    private void OnTriggerEnter(Collider other)
    {
        // Looking into the Core Mechanics, we can see that the GravityWell is what we see. By checking to see if the object that triggered this has the GravityWell component, we will then allow the code to run.
        if (other.GetComponent<GravityWell>() != null)
        {
            // By making a varible, we can make the code run a little better.
            GameObject spawn = GetObjectFromPool();

            // Moved the FSG to the GravityWell.
            spawn.transform.position = other.transform.position;

            // We then want to turn on one Object from the pool.
            spawn.SetActive(true);
        }
    }
}
