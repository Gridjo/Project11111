using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunT : MonoBehaviour
{
    [SerializeField] float rateOfFire = 4f;
    [SerializeField] Transform gunPoint;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        if(gunPoint == null)
            gunPoint = GetComponentInChildren<GunPoint>().transform;
    }
    public float GetRateOfFire()
    {
        return rateOfFire;   
    }

    public void Fire()
    {
        bullet = BulletManager.SharedInstance.GetPooledObject();
        bullet.transform.position = gunPoint.transform.position;
        bullet.transform.rotation = gunPoint.transform.rotation;
        bullet.SetActive(true);
    }
}

