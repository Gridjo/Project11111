using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIModulsIInfo : MonoBehaviour
{

    //public static UIModulsIInfo Instance;
    public GameObject prefabInfoPanel;
    public TextMeshPro typeValue, rarityValue, shotCostValue, damageValue, durValue, durStartValue, durCoefValue, shotTypeValue, recCostValue, magCapacity, typeBullet;
    public string StypeValue, SrarityValue, SshotCostValue, SdamageValue, SdurValue, SdurStartValue, SdurCoefValue, SshotTypeValue, SrecCostValue, SmagCapacity, StypeBullet;
    private GameObject InitedPanel;
    private void Awake()
    {
        //Instance = this;
    }

    private void ParseModuleInfo(Moduls item)
    {
        StypeValue = Moduls.GetTypeShotName(item.mType);
        SrarityValue = Moduls.GetRarityName(item.Raryti);
        SdurValue = item.durability.ToString();
        SdurStartValue = item.startDurability.ToString();
        SdurCoefValue = item.durCoef.ToString();
        SrecCostValue = item.recCost.ToString();
        if (item.mType == ModuleReplacement.ModuleType.barrel)
        {
            SshotCostValue = item.gameObject.GetComponent<bareModul>().junkPerShot.ToString();
            SdamageValue = item.gameObject.GetComponent<bareModul>().damage.ToString();
            StypeBullet = Moduls.GetTypeBulletName(item.gameObject.GetComponent<bareModul>().bulletType);
        }
        else
        {
            SshotCostValue = "Nope";
            SdamageValue = "Nope";
            StypeBullet = "Nope";
        }
        if (item.mType == ModuleReplacement.ModuleType.body)
        {
            SmagCapacity = item.gameObject.GetComponent<bodyModul>().magCapacity.ToString();
        }
        else
        {
            SmagCapacity = "Nope";
        }
    }    

    private void SetterModuleInfo()
    {
        typeValue.text = StypeValue;
        rarityValue.text = SrarityValue;
        shotCostValue.text = SshotCostValue;
        damageValue.text = SdamageValue;
        durValue.text = SdurValue;
        durStartValue.text = SdurStartValue;
        durCoefValue.text = SdurCoefValue;
        shotTypeValue.text = SshotTypeValue;
        recCostValue.text = SrecCostValue;
        magCapacity.text = SmagCapacity;
        typeBullet.text = StypeBullet;
    }

    private void ShowInfoPanel(GameObject module)
    {
        InitedPanel = Instantiate(prefabInfoPanel, new Vector3(0, 0.23f, 0), prefabInfoPanel.transform.rotation, module.transform);
    }
    
    public void ShowInfo(HVRGrabberBase hVRGrabberBase, HVRGrabbable hVRGrabbable)
    {
        if(hVRGrabbable.TryGetComponent(out Moduls item))
        {
            ParseModuleInfo(item);
            SetterModuleInfo();
            ShowInfoPanel(item.gameObject);
        }
    }

    public void HideInfo(HVRGrabberBase hVRGrabberBase, HVRGrabbable hVRGrabbable)
    {
        if (hVRGrabbable.TryGetComponent(out Moduls item))
        {
            Destroy(InitedPanel);
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
