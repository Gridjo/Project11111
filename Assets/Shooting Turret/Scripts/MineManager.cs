using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Samples;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private Collider Col;
    private Transform platformTransform;
    private Vector3 platMineAngle;
    private float x;
    private float z;
    private Vector3 OTPCoord;
    public Transform platformparent;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            reroll: ;
            x = Random.Range(-3f, 3f);
            z = Random.Range(-0.7f, 3f);
            if (((x < 0.6f) && (z < 0.6f)) || ((x < -0.6f) && (z < 0.6f)) || (z < -0.3f))
            { goto reroll; }
            OTPCoord = new Vector3(x, 0f, z);
            tmp.transform.SetParent(platformparent);
            tmp.transform.localPosition = OTPCoord;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    void Update()
    {
        GameObject tmp;
        if (Input.GetKeyDown(KeyCode.Space))// rework button
        {
            for (int j = 0; j < amountToPool; j++)
            {
                pooledObjects[j].SetActive(false);
            }

            for (int i = 0; i < amountToPool; i++)
            {
                reroll: ;
                x = Random.Range(-3f, 3f);
                z = Random.Range(-0.7f, 3f);
                if (((x < 0.6f) && (z < 0.6f)) || ((x < -0.6f) && (z < 0.6f)) || (z < -0.3f))
                { goto reroll; }
                OTPCoord = new Vector3(x, 0f, z);
                pooledObjects[i].transform.SetParent(platformparent);
                pooledObjects[i].transform.localPosition = OTPCoord;
                pooledObjects[i].SetActive(true);
            }
        }
    }
}
