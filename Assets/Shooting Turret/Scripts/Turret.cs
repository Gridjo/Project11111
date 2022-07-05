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

    public void Start()
    {
        targetTransform = FindObjectOfType<EnemyMele>().transform;
        //targetTransform = FindObjectOfType<EnemyRange>().transform;
        turretTransform = FindObjectOfType<Platform>().transform;
        currentGun = GetComponentInChildren<GunT>();
        fireRate = currentGun.GetRateOfFire();
        turretLifetime = 120f;
    }

    private void Update()
    {
        targetTransform = FindObjectOfType<EnemyMele>().transform;
        turretLifetime -= Time.deltaTime;
        if(turretLifetime <= 0)
        {
            turretObj.SetActive(false);
            turretLifetime = 120f;
        }
        Vector3 playerGroundPos = new Vector3(targetTransform.position.x, 
            transform.position.y, targetTransform.position.z);
        
        
        if((Vector3.Distance(transform.position, playerGroundPos) > turretRange))
           //|| (Vector3.Angle(turretTransform.forward, (targetTransform.position - turretTransform.position))) > (degrees / 2))
        {
            return;
        }
        
        Vector3 playerDirection = playerGroundPos - transform.position;
        float turretRotationStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection,
                                   turretRotationStep, 0f);
        transform.rotation = Quaternion.LookRotation(newLookDirection);

        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta <= 0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
