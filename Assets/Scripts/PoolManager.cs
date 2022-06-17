using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int CountPool = 11;
    public GameObject prefab;
    public GameObject plat;
    public GameObject GameManager11;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CountPool; i++)
        {
            
            var e = Instantiate(prefab);
            e.transform.SetParent(gameObject.transform, false);
            e.GetComponent<Enemy>().goal = plat.transform;
            e.GetComponent<Enemy>().enemyPool = gameObject;
            e.GetComponent<Enemy>().GameManager1 = GameManager11;
        }
    }

   
}
