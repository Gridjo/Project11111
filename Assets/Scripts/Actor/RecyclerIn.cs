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
            costil.RecyclerCost = item.junkPrice;
            if (item)
            {
                PlayerVariables.Instance.AddScraps(costil);
                item.gameObject.SetActive(false);
                item.transform.SetParent(ModPull.transform, false);
                item.transform.position = new Vector3();
                item.transform.localPosition = new Vector3();
                
            }
            else {
                Debug.Log("wkjerhfvi;uwgfiuweglfiyygweiufgwekygfoifhrlilwhfliwejfliwejfliw");
            }
        }
        else
        {
            Debug.LogError("Nullable item. lol");
        }
        recOut.TakeScrap();
    }
}
