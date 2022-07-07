using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private Collider Col;
    public float timeToDestroy = 2f;
    
    void Awake () 
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
     
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ggwp" )  
        {
            GunT.bullet.SetActive(false);
            transform.GetComponentInParent<Enemy>().GetDamage(4);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    void Update()
    {
       /* if (Turret.tmp == 1)
        {
            if (timeToDestroy <= 0)
            {
                GunT.bullet.SetActive(false);
                timeToDestroy = 1f;
            }
            timeToDestroy -= Time.deltaTime;
        }*/
    }
}
