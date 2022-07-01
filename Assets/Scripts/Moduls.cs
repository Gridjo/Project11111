using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Weapons.Guns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moduls : MonoBehaviour
{
    public bool AlreadyInGun;
    public Rarity Raryti;
    public float durCoef;
    public int junkPrice;
    public float durability;
    public float startDurability = 100f;
    public float subDurability;
    public bool IsBroken() { return durability <= 0; }

    public float junkPerShoot_barrel;
    public float durCoef_stock;

    private ModulsInfo script_stock;
    private bareModul script_barrel;
    private GameObject pistolMain;
    private bool ItCritical = false;

    private void Awake()
    {
        durability = startDurability;
        PreInit();
    }

    private void PreInit()
    {
        Subscribe();
        Init();
    }

    public void SubInit()
    {
        PreInit();
        Reconfigurator();
    }

    public void Init()
    {
        if (gameObject.GetComponent<bareModul>())
        {
            script_barrel = gameObject.GetComponent<bareModul>();
            ItCritical = true;
        }
        if (gameObject.GetComponent<ModulsInfo>())
        {
            script_stock = gameObject.GetComponent<ModulsInfo>();
            ItCritical = false;
        }
        if (gameObject.GetComponent<bodyModul>())
            ItCritical = true;
        if (AlreadyInGun)
        {
            pistolMain = FindParentPistol();
        }
        else
        {
            if (pistolMain != null)
            {
                pistolMain = null;
            }
        }
    }

    private void FixedUpdate()
    {
        if (AlreadyInGun)
        {
            if (IsBroken())
                Destroy();
        }
    }

    public void Reconfigurator()
    {
            try
            {
                script_barrel = FindParentPistol().GetComponent<ModulAllInGun>().barrel;
                junkPerShoot_barrel = script_barrel.junkPerShot;
            }
            catch (NullReferenceException z)
            {
                junkPerShoot_barrel = 1;
            }
            try 
            {
                script_stock = FindParentPistol().GetComponent<ModulAllInGun>().stock;
                durCoef_stock = script_stock.durCoef;
            }
            catch (NullReferenceException e)
            {
                durCoef_stock = 1f;
            }
            
            subDurability = junkPerShoot_barrel * durCoef * durCoef_stock;
        
        
    }

    GameObject FindParentPistol()
    {
       return transform.parent.parent.gameObject;
    }

    public void Subscribe()
    {
        if (AlreadyInGun)
        {
            Debug.Log("Sub");
            /*
            var fir = FindParentPistol().GetComponent<HVRPistol>().Fired;
            fir.AddListener(DurabilitySub);
            Debug.Log($"{fir.GetPersistentEventCount()}");
            */


            FindParentPistol().GetComponent<HVRPistol>().aFired.AddListener(DurabilitySub);
            Debug.Log($"{FindParentPistol().GetComponent<HVRPistol>().aFired.GetPersistentEventCount()}");
        }
    }

    public void DurabilitySub()
    {
        Debug.Log("DuSub");
        durability -= subDurability;
    }

    public void Destroy()
    {
        Debug.Log("DeSub");
        //act.RemoveListener(DurabilitySub);
        pistolMain.GetComponent<HVRPistol>().aFired.RemoveListener(DurabilitySub);
        gameObject.SetActive(false);
        if (ItCritical)
        {
            pistolMain.GetComponent<HVRPistol>().CriticalModuleIsBroken = IsBroken();
        }
        
    }
}

public enum Rarity
{
    Common = 5,
    Rare = 10,
    Epic = 20,
    Legendary = 45
}
