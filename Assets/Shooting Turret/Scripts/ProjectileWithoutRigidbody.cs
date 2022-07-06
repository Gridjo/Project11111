using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWithoutRigidbody : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 15f;
    public float timetodestr;
    public GameObject BULLET; 

    private void Start()
    {
        timetodestr = 2.5f;
    }
    private void Update()   //you can change this to a virtual function for multiple projectile types
    {
        timetodestr -= Time.deltaTime;
        if (timetodestr <= 0)
        {
            BULLET.SetActive(false);
            timetodestr = 2.5f;
        }
        transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    }
}
