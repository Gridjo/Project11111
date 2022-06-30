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
    public GameObject ModPoolSpawnPoint;
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
            if (hvrp.CanIsModificate)
            {
                if (other.TryGetComponent<Moduls>(out Moduls modsInfo))
                    if (modsInfo.AlreadyInGun)
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
        module.transform.position = ModPoolSpawnPoint.transform.position;
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 0, 0);
        _module = other.gameObject;
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
        module.gameObject.GetComponent<Rigidbody>().isKinematic = false;
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
        module.transform.position = ModPoolSpawnPoint.transform.position;
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 0, 0);
        _module = other.gameObject;
        if (module.GetComponent<bodyModul>().magCapacity > _module.GetComponent<bodyModul>().magCapacity)
        {
            if (_mainPistol.GetComponent<HVRPistol>().GameAmmo > _module.GetComponent<bodyModul>().magCapacity)
            {
                int ostatok = _mainPistol.GetComponent<HVRPistol>().GameAmmo;
                _mainPistol.GetComponent<HVRPistol>().GameAmmo = 0;
                Scrap sc = new Scrap();
                sc.AmountScrap = ostatok;
                PlayerVariables.Instance.AddScraps(sc);
            }
        }
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
        module.gameObject.GetComponent<Rigidbody>().isKinematic = false;
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
        module.transform.position = ModPoolSpawnPoint.transform.position;
        module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 1, 0);
        _module = other.gameObject;
        module.GetComponent<Moduls>().AlreadyInGun = false;
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        module.gameObject.AddComponent<Rigidbody>().isKinematic = true; 
        module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
        module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        module.TryGetComponent(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
        module.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void StockReplace(HVRGrabbable grb, Collider other)
    {
        FindStock();
        grb.ForceRelease();
        grb.enabled = false;
        try
        {
            module.transform.SetParent(null);
        } catch (NullReferenceException e) {}
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        try
        {
            module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        }
        catch (NullReferenceException e) {}
        Destroy(other.GetComponent<Rigidbody>());
        try
        {
            module.transform.position = ModPoolSpawnPoint.transform.position;
            module.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        }
        catch (NullReferenceException e) {}
        FindStockPlace();
        other.transform.SetParent(_stockPlace);
        //other.transform.localPosition = new Vector3(0, 0, 0.125f);
        _module = other.gameObject;
        try
        {
            module.GetComponent<Moduls>().AlreadyInGun = false;
        } catch (NullReferenceException e) { }
        _module.GetComponent<Moduls>().AlreadyInGun = true;
        _module.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _module.transform.localScale = new Vector3(0.045f, 0.03f, 0.06f);
        try
        {
            module.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            module.gameObject.GetComponent<HVRGrabbable>().Rigidbody = module.gameObject.GetComponent<Rigidbody>();
            module.gameObject.GetComponent<HVRGrabbable>().enabled = true;
            module.TryGetComponent(out HVRGrabbable grbb);
            grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
            module.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        catch (NullReferenceException e) {}
    }

    public enum ModuleType
    {
        body,
        barrel,
        stock
    }
}
