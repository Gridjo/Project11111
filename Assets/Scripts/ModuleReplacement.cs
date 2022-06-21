using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Weapons.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleReplacement : MonoBehaviour
{
    public GameObject pistol;
    public ModuleType moduleType;
    private GameObject slider;
    private GameObject _slider;
    private Transform _mainPistol;
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


    void FindPistolBody()
    {
        //_mainPistol = gameObject.transform.parent.parent;
        for(int x = 0; x < pistol.transform.childCount; x++)
        {
            if(pistol.transform.GetChild(x).CompareTag("Slide"))
            {
                this.slider = pistol.transform.GetChild(x).gameObject;
                Debug.Log("Slide found");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.TryGetComponent<HVRGrabbable>(out HVRGrabbable grb) && other.gameObject.tag == "Slide") 
        {
            BodyReplace(grb, other);
        }

    }

    void PistolBodyReplace(HVRGrabbable grb, Collider other)
    {
        Debug.Log("fuckthis1");
        FindPistolBody();
        grb.ForceRelease();
        grb.enabled = false;
        slider.transform.SetParent(null);
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Debug.Log("fuckthis2");
        Destroy(other.GetComponent<Rigidbody>());
        slider.transform.position = new Vector3(0, 0, 0);
        slider.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        Debug.Log("fuckthis3");
        other.transform.SetParent(pistol.transform);
        Debug.Log("fuckthis3.1");
        other.transform.localPosition = new Vector3(0, 1, 0);
        Debug.Log("fuckthis4");
        _slider = other.gameObject;
        Debug.Log("fuckthis4.1");
        _slider.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        Debug.Log("fuckthis4.2");
        _slider.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        Debug.Log("fuckthis5");
        slider.gameObject.AddComponent<Rigidbody>();
        Debug.Log("fuckthis5.1");
        slider.gameObject.GetComponent<HVRGrabbable>().Rigidbody = slider.gameObject.GetComponent<Rigidbody>();
        Debug.Log("fuckthis5.2");
        slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Debug.Log("fuckthis6");
        slider.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
        Debug.Log("fuckthis7");
    }

    void RifleBodyReplace(HVRGrabbable grb, Collider other)
    {
        FindPistolBody();
        grb.ForceRelease();
        grb.enabled = false;
        slider.transform.SetParent(null);
        grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
        slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        Destroy(other.GetComponent<Rigidbody>());
        slider.transform.position = new Vector3(0, 0, 0);
        slider.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f);
        other.transform.SetParent(pistol.transform);
        other.transform.localPosition = new Vector3(0, 1, 0);
        _slider = other.gameObject;
        _slider.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
        _slider.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
        slider.gameObject.AddComponent<Rigidbody>();
        slider.gameObject.GetComponent<HVRGrabbable>().Rigidbody = slider.gameObject.GetComponent<Rigidbody>();
        slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
        slider.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
        grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;
    }

    void BodyReplace(HVRGrabbable grb, Collider other)
    {
        Debug.Log($"My name is {_mainPistol.gameObject.name}");
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

    }

    void StockReplace(HVRGrabbable grb, Collider other)
    {

    }

    public enum ModuleType
    {
        body,
        barrel,
        stock
    }
}
