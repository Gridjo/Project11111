using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleReplacement : MonoBehaviour
{
    public GameObject pistol;
    private GameObject slider;
    private GameObject _slider;
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


    void FindSlider()
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
        if (other.TryGetComponent<HVRGrabbable>(out HVRGrabbable grb) && other.gameObject.tag == "Slide" )
        {
            Debug.LogAssertion("fuckthisslider1");
            FindSlider();
            Debug.LogAssertion("fuckthisslider2");
            grb.ForceRelease();
            Debug.LogAssertion("fuckthisslider3");
            grb.enabled = false;
            
            Debug.LogAssertion("fuckthisslider4");
          //  slider.GetComponent<Rigidbody>().isKinematic = false;,
            Debug.LogAssertion("fuckthisslider5");
            slider.transform.SetParent(null);
            Debug.LogAssertion("fuckthisslider6");
            //slider.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 1);
            Debug.LogAssertion("fuckthisslider7");

            grb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.None;
            slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
            Destroy(other.GetComponent<Rigidbody>());
            slider.transform.position = new Vector3(0, 0, 0);
            slider.transform.localScale = new Vector3(0.212989f, 0.03221213f, 0.04259932f); 
            // other.GetComponent<Rigidbody>().isKinematic = true;
            Debug.LogAssertion("fuckthisslider8");
            other.transform.SetParent(pistol.transform);
            Debug.LogAssertion("fuckthisslider9");
            other.transform.localPosition = new Vector3(0,1,0);
            _slider = other.gameObject;
            _slider.transform.localRotation = new Quaternion(0f, 270f, 0f, 0f);
            _slider.transform.localScale = new Vector3(0.04259932f, 0.03221213f, 0.212989f);
            //other.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0f, 270f, 0f, 1f));
            Debug.LogAssertion("fuckthisslider10");
            slider.gameObject.AddComponent<Rigidbody>();
            slider.gameObject.GetComponent<HVRGrabbable>().Rigidbody = slider.gameObject.GetComponent<Rigidbody>();
            slider.gameObject.GetComponent<HVRGrabbable>().enabled = true;
            slider.TryGetComponent<HVRGrabbable>(out HVRGrabbable grbb);
            grbb.TrackingType = HurricaneVR.Framework.Shared.HVRGrabTracking.ConfigurableJoint;


            /*Debug.Log("true Collision");
            other.gameObject.tag = "Untagged";
            Debug.Log("Untaged");
            gameObject.transform.parent.parent.GetChild(1).parent = null;
            Debug.Log("ppp");
            other.gameObject.transform.SetParent(pistol.transform);
            Debug.Log("setparent");
            other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Kinem");
            other.gameObject.transform.position = new Vector3(0,0,0);
            Debug.Log("Vector");
            other.gameObject.transform.rotation = new Quaternion(0, 270, 0, 0);*/

        }
    }
}
