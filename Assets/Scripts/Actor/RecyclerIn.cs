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

    private bool scrapBeSpawned = false;

    private void Awake()
    {
        ScrapText.text = "0";

        //Debug moment, lol
        //Spawn of scrap after start game
        
    }

    public void ShowBagScrapText()
    {
        ScrapText.text = $"{PlayerVariables.Instance.GetBagScrapsAmount()}";
    }

    private void FixedUpdate()
    {

    }

    private void FuckLog(int num)
    {
        Debug.LogError($"FUCK {num}");
    }

    public void AddScrapToRecycle(HVRGrabberBase grabberBase, HVRGrabbable grabbable)
    {
        Debug.Log("FUCKTHIS 1");
        if(grabbable.TryGetComponent(out Scrap scrap))
        {
            Debug.Log("FUCKTHIS 2");
            if (scrap)
            {
                Debug.Log("FUCKTHIS 3");
                grabbable.Socket.ForceRelease();
            }
        }
        else if (grabbable.TryGetComponent(out RecyclerItem item))
        {
            Debug.Log("FUCKTHIS 4");
            if (item)
            {
                PlayerVariables.Instance.AddScraps(item);
                Destroy(item.gameObject);
                Debug.Log("FUCKTHIS 5");
            }
        }
        else
        {
            Debug.LogError("Nullable item. lol");
        }
        Debug.Log("FUCKTHIS 6");
        recOut.TakeScrap();
        ShowBagScrapText();
        Debug.Log("FUCKTHIS 7");
    }
}
