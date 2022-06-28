using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class LandMine : MonoBehaviour
{
    public GameObject landMine;
    public GameObject explosive;
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "MeleEntity")|| (other.gameObject.tag == "RangeEntity"))// in main code rework tags
        {
            Instantiate(explosive, landMine.transform.position,landMine.transform.rotation);
            explosive.SetActive(true);
            landMine.SetActive(false);
        }
        if (other.gameObject.tag == "NPC")// in main code rework tags
        {
            NavMeshAgent agent
           = other.gameObject.GetComponent<NavMeshAgent>();
            agent.speed  = 2;
        }
        }

    void Update()
    {
        
    }
}
