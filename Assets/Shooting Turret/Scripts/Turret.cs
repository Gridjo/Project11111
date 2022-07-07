using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    [SerializeField] float turretRange = 13f;
    [SerializeField] float turretRotationSpeed = 5f;
    private Transform targetTransform;
    private GunT currentGun;
    private float fireRate;
    private float fireRateDelta;
    private Transform turretTransform;
    public int degrees;
    public float turretLifetime;
    public GameObject turretObj;
    public static int tmp = 0;
    Vector3 playerGroundPos;
    public Collider col;
    public void Start()
    {
        turretTransform = FindObjectOfType<turretdirection>().transform;
        currentGun = GetComponentInChildren<GunT>();
        fireRate = currentGun.GetRateOfFire();
        turretLifetime = 25f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="MeleEntity")
        {
            targetTransform = FindObjectOfType<EnemyMele>().transform;
            tmp = 1;
            return;
        }
        if (other.gameObject.tag == "RangeEntity")
        {
            targetTransform = FindObjectOfType<EnemyRange>().transform;
            tmp = 1;
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "MeleEntity")
        {
            tmp = 0;
            col.enabled = false;
            col.enabled = true;
            return;
        }
        if (other.gameObject.tag == "RangeEntity")
        {
            tmp = 0;
            col.enabled = false;
            col.enabled = true;
            return;
        }
    }

    private void Update()
    {
        if (!targetTransform.gameObject.activeSelf)
        {
            tmp = 0;
        }
        turretLifetime -= Time.deltaTime;
        if(turretLifetime <= 0)
        {
            turretObj.SetActive(false);
            turretLifetime = 25f;
        }
        if (tmp == 1)
        {
            playerGroundPos = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z);
        }

        if (tmp == 0)
        {
            if ((Vector3.Distance(transform.position, playerGroundPos) > turretRange))
            //|| (Vector3.Angle(turretTransform.forward, (targetTransform.position - turretTransform.position))) > (degrees / 2))
            {
                return;
            }
        }
            Vector3 playerDirection = playerGroundPos - transform.position;
            float turretRotationStep = turretRotationSpeed * Time.deltaTime;
            Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
                                       turretRotationStep, 0f);
            transform.rotation = Quaternion.LookRotation(newLookDirection);

            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                if (tmp == 1)
                {
                    currentGun.Fire();
                }
                fireRateDelta = fireRate;
            }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
