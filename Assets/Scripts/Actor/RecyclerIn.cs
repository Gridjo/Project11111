using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecyclerIn : MonoBehaviour
{
    public TextMeshPro ScrapText;
    public RecyclerOut recOut;
    public GameObject ModPull;

    private bool scrapBeSpawned = false;

    private void Awake()
    {
        ScrapText.text = "0";
    }

    public void ShowBagScrapText()
    {
        ScrapText.text = $"{PlayerVariables.Instance.GetBagScrapsAmount()}";
    }

    private void FixedUpdate()
    {
        ShowBagScrapText();
    }

    //I have fun, you have fun, we have fun...
    

    public void AddScrapToRecycle(HVRGrabberBase grabberBase, HVRGrabbable grabbable)
    {
        if (grabbable.TryGetComponent(out Moduls item))
        {
            RecyclerItem costil = new RecyclerItem();
            costil.RecyclerCost = (int)(1 /item.startDurability * item.durability * item.junkPrice + Moduls.GetRarityValue(item.Raryti));
            if (item)
            {
                //gameObject.GetComponent<HVRSocket>().ForceRelease();
                PlayerVariables.Instance.AddScraps(costil);
                // item.gameObject.SetActive(false);
                GameObject t=Instantiate(item.gameObject, ModPull.transform.position, ModPull.transform.rotation, ModPull.transform);
                t.SetActive(false);
                Destroy(item.gameObject);
                recOut.TakeScrap();
            }
            else {
                Debug.Log("wkjerhfvi;uwgfiuweglfiyygweiufgwekygfoifhrlilwhfliwejfliwejfliw");
            }
        }
    }
}
