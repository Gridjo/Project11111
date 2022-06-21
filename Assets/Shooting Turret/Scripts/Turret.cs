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

    private void Start()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        currentGun = GetComponentInChildren<GunT>();
        fireRate = currentGun.GetRateOfFire();
    }

    private void Update()
    {
        Vector3 playerGroundPos = new Vector3(targetTransform.position.x, 
            transform.position.y, targetTransform.position.z);

        //Check if player is not in range, then do nothing
        if(Vector3.Distance(transform.position, playerGroundPos) > turretRange)
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
        Gizmos.DrawWireSphere(transform.position, turretRange); //Show a gizmo when selected
    }
}
