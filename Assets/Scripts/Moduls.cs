using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Weapons.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moduls : MonoBehaviour
{
    public bool AlreadyInGun;
    public Rarity Raryti;
    public float durCoef;
    public int junkPrice;
    public float durability;
    public float junkPerShoot_barrel;
    public float durCoef_stock;
    public bool IsBroken() { return durability <= 0; }

    private ModulsInfo script_stock;
    private bareModul script_barrel;
    private bool ItCritical = false;

    void Start()
    {
        if (gameObject.GetComponent<bareModul>())
            ItCritical = true;
        if (gameObject.GetComponent<bodyModul>())
            ItCritical = true;
        if (AlreadyInGun)
        {
            Reconfigurator();
        }
    }

    private void FixedUpdate()
    {
        if (ItCritical)
            FindParentPistol().GetComponent<HVRPistol>().CriticalModuleIsBroken = IsBroken();
    }

    void Reconfigurator()
    {
            if (FindParentPistol().GetComponent<HVRPistol>().TypeGun == TypeGun.rifle)
            {
                FindBarre().TryGetComponent(out script_barrel);
                if (FindStock().TryGetComponent(out script_stock))
                {
                    durCoef_stock = script_stock.durCoef;
                }
                else
                {
                    durCoef_stock = 1f;
                }
                junkPerShoot_barrel = script_barrel.junkPerShot;

                durability = junkPerShoot_barrel * durCoef * durCoef_stock;
            }
            else
            {
                durability = durCoef;
            }
        
    }

    GameObject FindBarre()
    {
        for (int x = 0; x < FindParentPistol().gameObject.transform.childCount; x++)
        {
            for (int i = 0; i < FindParentPistol().gameObject.transform.GetChild(x).childCount; i++)
            {
                if (FindParentPistol().transform.GetChild(x).GetChild(i).TryGetComponent<bareModul>(out bareModul barm))
                {
                    return barm.gameObject;
                }
            }
        }
        return null;
    }
    GameObject FindStock()
    {
        for (int x = 0; x < FindParentPistol().gameObject.transform.childCount; x++)
        {
            for (int i = 0; i < FindParentPistol().gameObject.transform.GetChild(x).childCount; i++)
            {
                if (FindParentPistol().transform.GetChild(x).GetChild(i).TryGetComponent<ModulsInfo>(out ModulsInfo stm))
                {
                    return stm.gameObject;
                }
            }
        }
        return null;
    }

    GameObject FindParentPistol()
    {
        GameObject gO = transform.parent.parent.gameObject;
        return gO;
    }
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
