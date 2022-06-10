using HurricaneVR.Framework.ControllerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisible : MonoBehaviour
{
    public GameObject PlayerController;
    private HVRPlayerInputs hVRPlayerInputs;

    private bool isVisible = false;

    private void Update()
    {
        if (PlayerController.GetComponent<HVRPlayerInputs>().IsInventoryButton)
        {
            Debug.Log("hoba");
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
