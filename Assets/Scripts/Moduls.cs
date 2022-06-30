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

    public UnityEvent act;

    private ModulsInfo script_stock;
    private bareModul script_barrel;
    private GameObject pistolMain;
    private bool ItCritical = false;

    private void Awake()
    {
        durability = startDurability;
    }

    void Start()
    {
        Subscribe();
        Init();
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
            Reconfigurator();
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
        if (pistolMain.GetComponent<HVRPistol>().TypeGun == TypeGun.rifle)
        {
            if (script_barrel == null)
                script_barrel = FindParentPistol().GetComponent<ModulAllInGun>().barrel;
            try 
            {
                script_stock = FindParentPistol().GetComponent<ModulAllInGun>().stock;
                durCoef_stock = script_stock.durCoef;
            }
            catch (NullReferenceException e)
            {
                durCoef_stock = 1f;
            }
            junkPerShoot_barrel = script_barrel.junkPerShot;
            subDurability = junkPerShoot_barrel * durCoef * durCoef_stock;
        }
        else
        {
            subDurability = durCoef;
        }
        
    }

    GameObject FindParentPistol()
    {
        return transform.parent.parent.gameObject;
    }

    public Action a;

    public void Subscribe()
    {
        act = pistolMain.GetComponent<HVRPistol>().Fired;
        act.AddListener(DurabilitySub);
    }

    public void DurabilitySub()
    {
        durability -= subDurability;
    }

    public void Destroy()
    {
        act.RemoveListener(DurabilitySub);
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
