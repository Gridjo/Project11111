using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Weapons.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public int AmountScrap;
    private HVRGrabbable grb;
    private HVRPistol hvrp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gunn")
        {
            if (other.gameObject.TryGetComponent(out hvrp))
            {
                Debug.Log("Scrap_0");
                if (hvrp.CanReload)
                {
                    if (gameObject.TryGetComponent(out grb))
                    {
                        Debug.Log("Scrap_1");
                        ToInputScrapToAmmo(gameObject.GetComponent<HVRGrabbable>());
                    }
                }
            }
        }
    }
    

    private void ToInputScrapToAmmo(HVRGrabbable _grb)
    {
        if (PlayerVariables.Instance.TakeScraps(this, hvrp.TypeGun))
        {
            _grb.ForceRelease();
            Debug.Log("Reloading is success");
        }
        else
            Debug.Log("Reloading is failed");
    }
}
