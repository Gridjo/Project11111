using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclerOut : MonoBehaviour
{

    public GameObject prefabScrap;
    public RecyclerIn recIn;

    public static RecyclerOut Instance;



    private void Awake()
    {
        Instance = this;
        prefabScrap.GetComponent<HVRGrabbable>().StartingSocket = transform.GetComponentInParent<HVRSocket>();
        prefabScrap.GetComponent<HVRGrabbable>().LinkStartingSocket = true;
        prefabScrap.TryGetComponent(out Rigidbody rb);
    }
    public void TakeScrap()
    {
        //Spawn of scrap
        if (PlayerVariables.Instance.GetBagScrapsAmount() <= 0)
        {
            //20.06 upd
            if (prefabScrap)
            {
                prefabScrap.GetComponent<Rigidbody>().isKinematic = true;
                prefabScrap.SetActive(false);
            }
                
            return;
        }
        if (PlayerVariables.Instance.GetBagScrapsAmount() < prefabScrap.GetComponent<Scrap>().AmountScrap)
        {
            prefabScrap.GetComponent<Scrap>().AmountScrap = PlayerVariables.Instance.GetBagScrapsAmount();
        }
        if (gameObject.TryGetComponent(out HVRSocket _socket))
        {
            if (prefabScrap.TryGetComponent(out Scrap _scrap))
            {
                _scrap.AmountScrap = 10;
                prefabScrap.transform.localPosition = _socket.gameObject.transform.localPosition;
                prefabScrap.GetComponent<Rigidbody>().isKinematic = false;
                prefabScrap.SetActive(true);
                recIn.ShowBagScrapText();
            }
        }
        prefabScrap.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (PlayerVariables.Instance.GetBagScrapsAmount() <= 0)
        {
            //20.06 upd
            if (prefabScrap)
            {
                prefabScrap.GetComponent<Rigidbody>().isKinematic = true;
                prefabScrap.SetActive(false);
            }
                
        }
    }
}
