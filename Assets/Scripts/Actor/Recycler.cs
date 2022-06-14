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

        //Debug moment, lol
        //Spawn of scrap after start game
        
    }

    public void ShowBagScrapText()
    {
        ScrapText.text = $"{PlayerVariables.Instance.GetBagScrapsAmount()}";
    }

    public void TakeScrap(HVRGrabberBase grabberBase, HVRGrabbable grabbable)
    {
        //IDK, maybe not work
        //Spawn of scrap it time on event of hovering start

        //Variant 1
        /*
        if (gameObject.TryGetComponent<HVRSocket>(out HVRSocket _socket))
        {
            if (prefabScrap.TryGetComponent<Scrap>(out Scrap _scrap))
            {
                if (PlayerVariables.Instance.TakeScraps(_scrap))
                {
                    prefabScrap.transform.SetParent(_socket.gameObject.transform, false);
                    prefabScrap.transform.position = new Vector3(0, 0, 0);
                    //_socket.AutoSpawnPrefab = prefabScrap;
                    //_socket.CheckAutoSpawn();
                }
            }
        }
        */

        //Variant 2
        if (PlayerVariables.Instance.TakeScraps(prefabScrap.GetComponent<Scrap>()))
        {
            if (grabbable.TryGetComponent<Scrap>(out Scrap _scrap))
            {
                PlayerVariables.Instance.TakeScraps(_scrap);
            }
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
