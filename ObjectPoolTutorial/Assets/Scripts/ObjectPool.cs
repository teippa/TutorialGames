using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;
    public Queue<GameObject> pooledObjects;

    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;


    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new Queue<GameObject>();
        
        GameObject tmp;
        for (int i=0; i<amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, transform);
            tmp.SetActive(false);
            pooledObjects.Enqueue(tmp);
        }
    }


    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        pooledObjects.Enqueue(obj);

        return obj;
    }
}
