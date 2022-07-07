using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Samples;
using UnityEngine;
using HurricaneVR.Framework.ControllerInput;
using UnityEngine.UI;
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
    public GameObject PlayerController;
    public GameObject Gm;
    public Text text;
    private float timetoenable;

    void Start()
    {
        text.enabled = false;
        text.text = "NOT ENOUGH ENERGY";
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            reroll: ;
            x = Random.Range(0f, 3f);
            z = Random.Range(-3f, 3f);
            if (((x < 0.6f) && (z < 0.6f)) || ((x < 0.6f) && (z < -0.6f)) || (x < 0f))
            { goto reroll; }
            OTPCoord = new Vector3(x, -0.03f, z);
            tmp.transform.SetParent(platformparent);
            tmp.transform.localPosition = OTPCoord;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    void Update()
    {
        timetoenable -= Time.deltaTime;
        if (timetoenable <= 0)
        {
            text.enabled = false;
        }
        if ((PlayerController.GetComponent<HVRPlayerInputs>().IsCrouchActivated) && (Gm.GetComponent<GameManager>().Energy < 150))
        {
            text.enabled = true;
            timetoenable = 1f;
            return;
        }

        GameObject tmp;
        if ((PlayerController.GetComponent<HVRPlayerInputs>().IsCrouchActivated)&&(Gm.GetComponent<GameManager>().Energy >= 150))
        {
            Gm.GetComponent<GameManager>().Energy -= 100;
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
