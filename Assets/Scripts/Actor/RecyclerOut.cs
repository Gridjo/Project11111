using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerOut : MonoBehaviour
{

    public GameObject prefabScrap;
    public RecyclerIn recIn;

    private void Awake()
    {
        prefabScrap.GetComponent<HVRGrabbable>().StartingSocket = transform.GetComponentInParent<HVRSocket>();
        prefabScrap.GetComponent<HVRGrabbable>().LinkStartingSocket = true;
    }
    public void TakeScrap()
    {
        //Spawn of scrap
        Debug.Log("fuck1");
        if (PlayerVariables.Instance.GetBagScrapsAmount() <= 0)
        {
            //20.06 upd
            if (prefabScrap.activeInHierarchy)
                prefabScrap.SetActive(false);
            Debug.Log("fuck2");
            //prefabScrap.GetComponent<Scrap>().AmountScrap = 0;
            return;
        }
        if (PlayerVariables.Instance.GetBagScrapsAmount() < prefabScrap.GetComponent<Scrap>().AmountScrap)
        {
            prefabScrap.GetComponent<Scrap>().AmountScrap = PlayerVariables.Instance.GetBagScrapsAmount();
            Debug.Log("fuck3");
        }
        if (gameObject.TryGetComponent(out HVRSocket _socket))
        {
            Debug.Log("fuck4");
            if (prefabScrap.TryGetComponent(out Scrap _scrap))
            {
                Debug.Log("fuck5");
                _scrap.AmountScrap = 10;
                /*
                if (PlayerVariables.Instance.TakeScraps(_scrap))
                {
                    Instantiate(prefabScrap);
                    //_socket.AutoSpawnPrefab = prefabScrap;
                    //_socket.CheckAutoSpawn();
                }
                */
                
                prefabScrap.transform.localPosition = _socket.gameObject.transform.localPosition;
               
                prefabScrap.SetActive(true);
                recIn.ShowBagScrapText();
            }
        } 
    }
}
