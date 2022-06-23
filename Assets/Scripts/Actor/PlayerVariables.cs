using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    [Header("Player Controller")]
    private int scrapsBagHave;
    private int ammoScrap;
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

    private void Awake()
    {
        Instance = this;
    }

    public int GetBagScrapsAmount()
    {
        return scrapsBagHave;
    }

    public int GetAmmoScrapsAmount()
    {
        return ammoScrap;
    }

    public void AddAmmoScraps(Scrap scrap)
    {
        if (scrap.AmountScrap > 0)
        {
            ammoScrap += scrap.AmountScrap;
            Debug.Log(scrapsBagHave);
        }
        else
            Debug.LogError($"{scrap.gameObject.name} has cost is {scrap.AmountScrap}");
    }

    public bool TakeScraps(Scrap scrap)
    {
        if (scrap.AmountScrap > 0 && scrapsBagHave >= scrap.AmountScrap)
        {
            scrapsBagHave -= scrap.AmountScrap;
            return true;
        }
        else
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
