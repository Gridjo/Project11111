using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    public TextMeshPro ScrapText;
    public GameObject prefabScrap;

    private void Awake()
    {
        ScrapText.text = "0";
    }

    public void ShowBagScrapText()
    {
        ScrapText.text = $"{PlayerVariables.Instance.GetBagScrapsAmount()}";
    }

    public void TakeScrap()
    {
        if(gameObject.TryGetComponent<HVRSocket>(out HVRSocket socket))
        {
            
        }
    }

    public void AddScrapToRecycle(HVRGrabberBase grabberBase, HVRGrabbable grabbable)
    {
        if(grabbable.TryGetComponent(out RecyclerItem item) || grabbable.TryGetComponent(out Scrap scrap))
        {
            PlayerVariables.Instance.AddScraps(item);
            Destroy(item.gameObject);
            ShowBagScrapText();
        }
        else
        {
            Debug.LogError("Nullable item. lol");
        }
    }
}
