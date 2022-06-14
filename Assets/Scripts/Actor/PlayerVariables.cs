using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    private int scrapsBagHave;
    private int ammoScrap;
    public static PlayerVariables Instance;

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

    public void TakeScraps(Scrap scrap)
    {
        if (scrap.AmountScrap > 0)
        {
            scrapsBagHave -= scrap.AmountScrap;
            Debug.Log(scrapsBagHave);
        }
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
