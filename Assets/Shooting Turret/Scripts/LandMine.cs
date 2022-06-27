using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public GameObject landMine;
    public GameObject explosive;
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemytrigger")// in main code rework tags
        {
            Instantiate(explosive, landMine.transform.position,landMine.transform.rotation);
            explosive.SetActive(true);
            landMine.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
