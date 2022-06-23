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
            //Check need ammo and other
            
            //But it's not by writed
            if(gameObject.TryGetComponent(out grb))
            {

            }    
        }
    }

    private void ToInputScrapToAmmo()
    {

    }
}
