using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Weapons.Guns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleReplacement : MonoBehaviour
{
    public GameObject pistol;
    public ModuleType moduleType;
    private GameObject module;
    private GameObject _module;
    private Transform _mainPistol;
    private Transform _stockPlace;
    private bodyModul bodyModul;
    private HVRPistol hvrp;
    // Start is called before the first frame update
    private void Awake()
    {
        _mainPistol = gameObject.transform.parent.parent.parent;
        hvrp = _mainPistol.GetComponent<HVRPistol>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(_slider)
        {
            

        }*/
    }


    void FindBody()
    {
        //_mainPistol = gameObject.transform.parent.parent;
        for(int x = 0; x < pistol.transform.childCount; x++)
        {
            if(pistol.transform.GetChild(x).GetComponent<bodyModul>())
            {
                this.module = pistol.transform.GetChild(x).gameObject;
                Debug.Log("Body found");
            }
        }
    }

    void FindBarrel()
    {
        //_mainPistol = gameObject.transform.parent.parent;
        for (int x = 0; x < pistol.transform.childCount; x++)
        {
            if (pistol.transform.GetChild(x).GetComponent<bareModul>())
            {
                this.module = pistol.transform.GetChild(x).gameObject;
                Debug.Log("Barrel found");
            }
        }
    }

    void FindStock()
    {
        //_mainPistol = gameObject.transform.parent.parent;
        for (int x = 0; x < pistol.transform.childCount; x++)
        {
            if (pistol.transform.GetChild(x).GetComponent<ModulsInfo>())
            {
                this.module = pistol.transform.GetChild(x).gameObject;
                Debug.Log("Stock found");
            }
        }
    }

    void FindStockPlace()
    {
        //_mainPistol = gameObject.transform.parent.parent;
        for (int x = 0; x < pistol.transform.childCount; x++)
        {
            if (pistol.transform.GetChild(x).name == "stock")
            {
                this._stockPlace = pistol.transform.GetChild(x).gameObject.transform;
                Debug.Log("Stock place found");
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<HVRGrabbable>(out HVRGrabbable grb))
        {
            if (other.TryGetComponent<Moduls>(out Moduls modsInfo))
                if(modsInfo.AlreadyInGun)
                    return;
            if (other.GetComponent<bodyModul>())
            {
                if (this.moduleType == ModuleType.body)
                {
                    Debug.Log("This Body");
                    BodyReplace(grb, other);
                }
            }
            else if (other.GetComponent<bareModul>())
            {
                if (this.moduleType == ModuleType.barrel)
                {
                    Debug.Log("This Barrel");
                    BarrelReplace(grb, other);
                }
            }
            else if (other.GetComponent<ModulsInfo>())
            {
                if (this.moduleType == ModuleType.stock)
                {
                    Debug.Log("This Stock");
                    StockReplace(grb, other);
                }
            }
            hvrp.gameObject.GetComponent<ModulAllInGun>().ModulsFind();
        }

    }

    void PistolBodyReplace(HVRGrabbable grb, Collider other)
    {
        FindBody();
        grb.ForceRelease();
        grb.enabled = false;
        module.transform.SetParent(null);
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Destroy(other.GetComponent<Rigidbody>());
        module.transform.position = new Vector3(0, 0, 0);
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 1, 0);
        _module = other.gameObject;
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
    }

    void RifleBodyReplace(HVRGrabbable grb, Collider other)
    {
        FindBody();
        grb.ForceRelease();
        grb.enabled = false;
        module.transform.SetParent(null);
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Destroy(other.GetComponent<Rigidbody>());
        module.transform.position = new Vector3(0, 0, 0);
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 1, 0);
        _module = other.gameObject;
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
    }

    void BodyReplace(HVRGrabbable grb, Collider other)
    {
        if (_mainPistol.gameObject.GetComponent<HVRPistol>().TypeGun == TypeGun.pistol)
            PistolBodyReplace(grb, other);
        else if (_mainPistol.gameObject.GetComponent<HVRPistol>().TypeGun == TypeGun.rifle)
            RifleBodyReplace(grb, other);

        bodyModul = other.gameObject.GetComponent<bodyModul>();

        if (bodyModul.shootingType == shootingType.semi)
            hvrp.FireType = HurricaneVR.Framework.Weapons.FireType.Single;
        else if (bodyModul.shootingType == shootingType.burst)
            hvrp.FireType = HurricaneVR.Framework.Weapons.FireType.ThreeRoundBurst;
        else if (bodyModul.shootingType == shootingType.auto)
            hvrp.FireType = HurricaneVR.Framework.Weapons.FireType.Automatic;
    }

    void BarrelReplace(HVRGrabbable grb, Collider other)
    {
        FindBarrel();
        grb.ForceRelease();
        grb.enabled = false;
        module.transform.SetParent(null);
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Destroy(other.GetComponent<Rigidbody>());
        module.transform.position = new Vector3(0, 0, 0);
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 1, 0);
        _module = other.gameObject;
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
    }

    void StockReplace(HVRGrabbable grb, Collider other)
    {
        Debug.Log("fuckthis1");
        FindStock();
        Debug.Log("fuckthis2");
        grb.ForceRelease();
        Debug.Log("fuckthis3");
        grb.enabled = false;
        Debug.Log("fuckthis4");
        try
        {
            Debug.Log("fuckthis5");
            module.transform.SetParent(null);
        } catch (NullReferenceException e) {
            Debug.Log("fuckthis5.1");
        }
        Debug.Log("fuckthis6");
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        try
        {
            module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
            Debug.Log("fuckthis7");
        }
        catch (NullReferenceException e) { Debug.Log("fuckthis7.1"); }
        Destroy(other.GetComponent<Rigidbody>());
        Debug.Log("fuckthis8");
        try
        {
            Debug.Log("fuckthis9");
            Debug.Log(module.gameObject.name);
            module.transform.position = new Vector3(0, 0, 0);
            module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        }
        catch (NullReferenceException e) { Debug.Log("fuckthis9.1"); }
        Debug.Log("fuckthis10");
        FindStockPlace();
        other.transform.SetParent(_stockPlace);
        Debug.Log("fuckthis11");
        //other.transform.localPosition = new Vector3(0, 0, 0.125f);
        Debug.Log("fuckthis12");
        _module = other.gameObject;
        try
        {
            module.GetComponent<Moduls>().AlreadyInGun = false;
        } catch (NullReferenceException e) { }
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        Debug.Log("fuckthis13");
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        Debug.Log("fuckthis14");
        _module.transform.localScale = new Vector3(0.045f, 0.03f, 0.06f);
        Debug.Log("fuckthis15");
        try
        {
            module.gameObject.AddComponent<Rigidbody>();
            Debug.Log("fuckthis16");
            module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
            Debug.Log("fuckthis17");
            module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
            Debug.Log("fuckthis18");
            module.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
            Debug.Log("fuckthis19");
            grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
            Debug.Log("fuckthis20");
        }
        catch (NullReferenceException e) {
            Debug.Log("fuckthis20.1");
        }
        Debug.Log("fuckthis21");
    }

    public enum ModuleType
    {
        body,
        barrel,
        stock
    }
}
