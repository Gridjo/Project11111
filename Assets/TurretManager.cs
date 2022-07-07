using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.ControllerInput;
using UnityEngine.UI;

public class TurretManager : MonoBehaviour
{
    public GameObject PlayerController;
    public GameObject Gm;
    //public GameObject centerTurret;
    public GameObject leftTurret;
    public GameObject rightTurret;
    public Text text;
    private float timetoenable;

    void Start()
    {
        text.enabled = false;
        text.text = "NOT ENOUGH ENERGY";
    }

    void Update()
    {
        timetoenable -= Time.deltaTime;
        if(timetoenable <= 0)
        {
            text.enabled = false;
        }
        if ((PlayerController.GetComponent<HVRPlayerInputs>().IsStandActivated) && (Gm.GetComponent<GameManager>().Energy < 200))
        {
            text.enabled = true;
            timetoenable = 1f;
            return;
        }

            if ((PlayerController.GetComponent<HVRPlayerInputs>().IsStandActivated) && (Gm.GetComponent<GameManager>().Energy >= 200))
            {
                Gm.GetComponent<GameManager>().Energy -= 200;
                int tmp;
                tmp = Random.Range(1, 3);
                if (tmp == 1)
                {
                    if(leftTurret.activeSelf)
                    { 
                        return;
                    }
                    leftTurret.SetActive(true);
                }
                if (tmp == 2)
                {
                    if (rightTurret.activeSelf)
                    {
                        return;
                    }
                    rightTurret.SetActive(true);
                }
            }
    }
}
