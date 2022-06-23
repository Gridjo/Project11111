using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public int AmountScrap;
    private GameObject gun;
    private HVRPistol gunScript;
    private HVRGrabbable grb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out gunScript))
        {
            gun = gunScript.gameObject;
            if(gameObject.TryGetComponent(out grb))
            {


            }    
        }
    }

    private void ToInputScrapToAmmo()
    {
        if (PlayerVariables.Instance.TakeScraps(this))
        {
            Debug.Log("Reloading is success");
        }
        else
            Debug.Log("Reloading is failed");
    }
}
