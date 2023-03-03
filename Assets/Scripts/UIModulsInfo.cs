using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIModulsInfo : MonoBehaviour
{

    //public static UIModulsIInfo Instance;
    /*public GameObject prefabInfoPanel;
    private InfoModulsTextValues InfoPanel;
    private string StypeValue, SrarityValue, SshotCostValue, SdamageValue, SdurValue, SdurStartValue, SdurCoefValue, SshotTypeValue, SrecCostValue, SmagCapacity, StypeBullet;
    private GameObject InitedPanel;
    private HVRGrabbable hvrg;
    private void Awake()
    {
        Sub();
    }

    private void Sub()
    {
        hvrg = gameObject.GetComponentInParent<HVRGrabbable>();
        hvrg.HandGrabbed.AddListener(ShowInfo);
        hvrg.HandReleased.AddListener(HideInfo);
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
        InfoPanel = prefabInfoPanel.GetComponent<InfoModulsTextValues>();
        InfoPanel.typeValue.text = StypeValue;
        InfoPanel.rarityValue.text = SrarityValue;
        InfoPanel.shotCostValue.text = SshotCostValue;
        InfoPanel.damageValue.text = SdamageValue;
        InfoPanel.durValue.text = SdurValue;
        InfoPanel.durStartValue.text = SdurStartValue;
        InfoPanel.durCoefValue.text = SdurCoefValue;
        InfoPanel.shotTypeValue.text = SshotTypeValue;
        InfoPanel.recCostValue.text = SrecCostValue;
        InfoPanel.magCapacity.text = SmagCapacity;
        InfoPanel.typeBullet.text = StypeBullet;
    }

    private void ShowInfoPanel(GameObject module)
    {
        prefabInfoPanel.transform.localPosition = new Vector3(0f, 0.25f, 0f);
        prefabInfoPanel.transform.localRotation = new Quaternion(0f, 0f, 180f, 1f);
        InitedPanel = Instantiate(prefabInfoPanel, module.transform);
        
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
        
    }*/
}
