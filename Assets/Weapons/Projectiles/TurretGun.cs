using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float RateOfFire = 1f;

    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
