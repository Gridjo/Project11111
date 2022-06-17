using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleReplacement : MonoBehaviour
{
    public GameObject pistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Slide")
        {
            Debug.Log("true Collision");
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
            other.gameObject.transform.rotation = new Quaternion(0, 270, 0, 0);
             
        }
    }
}
