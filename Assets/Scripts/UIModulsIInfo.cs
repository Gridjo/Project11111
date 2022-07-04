using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIModulsIInfo : MonoBehaviour
{

    public static UIModulsIInfo Instance;
    public GameObject panel;
    public TextMeshPro typeValue, rarityValue, shotCostValue, damageValue, durValue, durStartValue, durCoefValue, shotTypeValue, recCostValue;


    private void Awake()
    {
        Instance = this;
    }

    
    public void ShowInfo(HVRGrabberBase hVRGrabberBase, HVRGrabbable hVRGrabbable)
    {
        if(hVRGrabbable.TryGetComponent(out Moduls item))
        {
            typeValue = 
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
