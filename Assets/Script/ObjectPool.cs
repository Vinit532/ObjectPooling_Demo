using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab to pool
    public int poolSize = 10; // Number of objects in the pool

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();

        // Populate the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false); // Deactivate to reuse later
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy) // Check if it's available
            {
                return obj;
            }
        }

        return null; // No available objects
    }
}
