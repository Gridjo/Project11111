using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Weapons.Guns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static ModuleReplacement;

public class Moduls : MonoBehaviour
{
    public bool AlreadyInGun;
    public Rarity Raryti;
    public float durCoef;
    public int junkPrice;
    public float durability;
    public float startDurability = 100f;
    public float subDurability;
    public int recCost;

    public ModuleType mType;
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
            mType = ModuleType.barrel;
        }
        if (gameObject.GetComponent<ModulsInfo>())
        {
            script_stock = gameObject.GetComponent<ModulsInfo>();
            ItCritical = false;
            mType = ModuleType.stock;
        }
        if (gameObject.GetComponent<bodyModul>())
        {
            ItCritical = true;
            mType = ModuleType.body;
        }
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

    private void ChangeAmmoSocketGun()
    {
        if(gameObject.GetComponent<bodyModul>().IsBroken())
        {
            if(pistolMain.GetComponent<HVRPistol>().GameAmmo > 0)
            {
                Scrap s = new Scrap();
                s.AmountScrap = pistolMain.GetComponent<HVRPistol>().GameAmmo;
                PlayerVariables.Instance.AddScraps(s);
                pistolMain.GetComponent<HVRPistol>().CanReload = false;
            }
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
            recCost = (int)(1 / startDurability * durability / 3 * junkPrice + Moduls.GetRarityValue(Raryti));

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
        if (TryGetComponent(out bodyModul body))
        {
            ChangeAmmoSocketGun();
        }
        pistolMain.GetComponent<HVRPistol>().aFired.RemoveListener(DurabilitySub);
        gameObject.SetActive(false);

        if (ItCritical)
        {
            pistolMain.GetComponent<HVRPistol>().CriticalModuleIsBroken = IsBroken();
        }
        
    }

    public static int GetRarityValue(Rarity r)
    {
        switch (r)
        {
            case Rarity.Common:
                return 5;
            case Rarity.Rare:
                return 10;
            case Rarity.Epic:
                return 20;
            case Rarity.Legendary:
                return 45;
            default:
                return Int32.MinValue;
        }
    }

    public static string GetRarityName(Rarity r)
    {
        switch (r)
        {
            case Rarity.Common:
                return "Common";
            case Rarity.Rare:
                return "Rare";
            case Rarity.Epic:
                return "Epic";
            case Rarity.Legendary:
                return "Legendary";
            default:
                return "None";
        }
    }

    public static string GetTypeShotName(ModuleType mT)
    {
        switch (mT)
        {
            case ModuleType.body:
                return "Body";
            case ModuleType.barrel:
                return "Barrel";
            case ModuleType.stock:
                return "Stock";
            default:
                return "None";
        }
    }

    public static string GetTypeBulletName(BuletType bT)
    {
        switch (bT)
        {
            case BuletType.single:
                return "Single";
            case BuletType.grenade:
                return "Grenade";
            case BuletType.shotgun:
                return "Shotgun";
            case BuletType.rocket:
                return "Rocket";
            default:
                return "None";
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
