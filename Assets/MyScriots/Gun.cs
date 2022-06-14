using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using HurricaneVR.Framework.Weapons.Guns;

public class Gun : MonoBehaviour
{
    public float cooldownSpeed;

    public float fireRate;

    public float recoilCooldown;

    private float accuracy;

    public float maxSpreadAngle;

    public float timeTillMaxSpread;

    public GameObject bullet;

    public GameObject shootPoint;

    public AudioSource gunshot;

    public AudioClip singleShot;

    // Start is called before the first frame update
    void Start()
    {
        var p = new HVRPistol();
        p.Ammo.AddBullet();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSpeed += Time.deltaTime * 60f;

        if (Input.GetButton("Fire1"))
        {
            accuracy += Time.deltaTime * 4f;
            if (cooldownSpeed >= fireRate)
            {
                Shoot();
                gunshot.PlayOneShot(singleShot);
                cooldownSpeed = 0;
                recoilCooldown = 1;
            }
        }
        else
        {
            recoilCooldown -= Time.deltaTime;
            if (recoilCooldown <= 1)
            {
                accuracy = 0.0f;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);

        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);

        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        if (Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation); 
            tempBullet.GetComponent<MoveBullet>().hitPoint = hit.point;
        }
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation); 
            tempBullet.GetComponent<MoveBullet>().hitPoint = hit.point;
        }
    }
}