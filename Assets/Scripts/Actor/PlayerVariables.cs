using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Weapons.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    [Header("Player Controller")]
    private int scrapsBagHave;
    public static PlayerVariables Instance;

    [Header("Guns")]
    public GameObject pistolGun;
    public GameObject rifleGun;

    [Header("Debug")]
    public bool playerUseLeftArm = false;
    public bool playerUseRightArm = false;
    public bool playerUseAnyArm() {
        if (playerUseLeftArm || playerUseRightArm)
        {
            return true;
        }
        else
            return false;
    }

    public void useLeftArm(bool zxc)
    {
        if (zxc)
            playerUseLeftArm = true;
        else
            playerUseLeftArm = false;
    }

    public void useRightArm(bool zxc)
    {
        if (zxc)
            playerUseRightArm = true;
        else
            playerUseRightArm = false;
    }

    public int GetAmmo(TypeGun type)
    {
        if (type == TypeGun.pistol)
            return pistolGun.GetComponent<HVRPistol>().GameAmmo;
        else if (type == TypeGun.rifle)
            return rifleGun.GetComponent<HVRPistol>().GameAmmo;
        else
            return -1;
    }

    public int GetMaxAmmo(TypeGun type)
    {
        if (type == TypeGun.pistol)
            return pistolGun.GetComponent<HVRPistol>().GameMaxAmmo;
        else if (type == TypeGun.rifle)
            return rifleGun.GetComponent<HVRPistol>().GameAmmo;
        else
            return -1;
    }

    private void Awake()
    {
        Instance = this;
    }

    public int GetBagScrapsAmount()
    {
        return scrapsBagHave;
    }

    public void AddAmmoScraps(Scrap scrap)
    {
        if (scrap.AmountScrap > 0)
        {
            
            Debug.Log(scrapsBagHave);
        }
        else
            Debug.LogError($"{scrap.gameObject.name} has cost is {scrap.AmountScrap}");
    }

    public bool TakeScraps(Scrap scrap, TypeGun typeGun)
    {
        if (scrap.AmountScrap > 0)
        {
            if (scrapsBagHave >= scrap.AmountScrap)
            {
                scrapsBagHave -= scrap.AmountScrap;
                if(typeGun == TypeGun.pistol)
                    scrapsBagHave += pistolGun.GetComponent<HVRPistol>().AddAmmo(scrap.AmountScrap);
                else if (typeGun == TypeGun.rifle)
                    scrapsBagHave += rifleGun.GetComponent<HVRPistol>().AddAmmo(scrap.AmountScrap);
                return true;
            }
            else
            {
                Scrap sc = new Scrap();
                sc.AmountScrap = scrapsBagHave;
                scrapsBagHave -= sc.AmountScrap;
                if (typeGun == TypeGun.pistol)
                    scrapsBagHave += pistolGun.GetComponent<HVRPistol>().AddAmmo(sc.AmountScrap);
                else if (typeGun == TypeGun.rifle)
                    scrapsBagHave += rifleGun.GetComponent<HVRPistol>().AddAmmo(sc.AmountScrap);
                return true;
            }
        }
        return false;
    }

    public void AddScraps(RecyclerItem item)
    {
        if (item.RecyclerCost > 0)
        {
            scrapsBagHave += item.RecyclerCost;
            Debug.Log(scrapsBagHave);
        }
        else
            Debug.LogError($"{item.gameObject.name} has cost is {item.RecyclerCost}");
    }

    public void AddScraps(Scrap scrap)
    {
        if (scrap.AmountScrap > 0)
        {
            scrapsBagHave += scrap.AmountScrap;
            Debug.Log(scrapsBagHave);
        }
        else
            Debug.LogError($"{scrap.gameObject.name} has cost is {scrap.AmountScrap}");
    }


}
