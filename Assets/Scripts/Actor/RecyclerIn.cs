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
            costil.RecyclerCost = item.recCost;
            PlayerVariables.Instance.AddScraps(costil);
            grabbable.ForceRelease();
            //grabbable.Grabbers.Clear();
            //grabbable.HandGrabbers.Clear();
            //grabbable.GrabPointsMeta.Clear();
            Destroy(item.gameObject.GetComponent<ConfigurableJoint>());
                
            gameObject.GetComponent<HVRSocket>().TryGrab(grabbable);
            gameObject.GetComponent<HVRSocket>().ForceRelease();
                
            // item.gameObject.SetActive(false);
            GameObject t=Instantiate(item.gameObject, ModPull.transform.position, ModPull.transform.rotation, ModPull.transform);
            t.GetComponent<Rigidbody>().useGravity = true;
            t.GetComponent<Moduls>().durability = t.GetComponent<Moduls>().startDurability;
            t.SetActive(false);
            Destroy(t.GetComponent<ConfigurableJoint>());
            Destroy(item.gameObject);
            recOut.TakeScrap();
            
        }
    }
}
