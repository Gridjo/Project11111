using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.ControllerInput;

public class TurretManager : MonoBehaviour
{
    public GameObject PlayerController;
    public GameObject Gm;
    //public GameObject centerTurret;
    public GameObject leftTurret;
    public GameObject rightTurret;
    void Start()
    {
        
    }

    void Update()
    {
        if ((PlayerController.GetComponent<HVRPlayerInputs>().IsStandActivated) && (Gm.GetComponent<GameManager>().Energy >= 200))
        {
            Gm.GetComponent<GameManager>().Energy -= 200;
            int tmp;
            tmp = Random.Range(1, 3);
            if (tmp == 1)
            {
                leftTurret.SetActive(true);
            }
            if (tmp == 2)
            {
                rightTurret.SetActive(true);
            }
        }
    }
}
