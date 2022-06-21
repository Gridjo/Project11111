using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleReplacement : MonoBehaviour
{
    public GameObject pistol;
    private GameObject slider;
    private GameObject _slider;
    public ModuleType moduleType;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Transform _mainPistol = gameObject.transform.parent.parent;
        for(int x = 0; x < _mainPistol.childCount; x++)
        {
            if(_mainPistol.GetChild(x).CompareTag("Slide"))
            {
                this.slider = _mainPistol.GetChild(x).gameObject;
                Debug.Log("Slide found");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.TryGetComponent<HVRGrabbable>(out HVRGrabbable grb) && moduleType == ModuleType.pistolBody)
        {
            PistolBodyReplace(grb, other);
        }

    }

    void PistolBodyReplace(HVRGrabbable grb, Collider other)
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
        pistolBody,
        barrel,
        stock
    }
}
