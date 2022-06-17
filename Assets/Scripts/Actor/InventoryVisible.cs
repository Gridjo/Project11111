using HurricaneVR.Framework.ControllerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisible : MonoBehaviour
{
    public GameObject PlayerController;

    private bool isVisible = true;
    private void Awake()
    {
        HideInventrory();
    }
    private void Update()
    {
        if (PlayerController.GetComponent<HVRPlayerInputs>().IsInventoryButton)
        {
            changeVisible();
        }
    }
    public void changeVisible()
    {
        if (isVisible)
            HideInventrory();
        else
            ShowInventory();
    }

    private void HideInventrory()
    {
        isVisible = false;
        for (int x = 0; x < transform.childCount; x++)
        {
            transform.GetChild(x).gameObject.SetActive(false);
        }
    }

    private void ShowInventory()
    {
        isVisible = true;
        for (int x = 0; x < transform.childCount; x++)
        {
            transform.GetChild(x).gameObject.SetActive(true);
        }
    }    
}
