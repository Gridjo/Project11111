using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float barrierHitPoints;
    public float maxbarrierHitPoints = 100f;
    public GameObject barrierObj;
    public GameObject centerBut;
    public GameObject leftBut;
    public GameObject rightBut;


    void Start()
    {
        barrierHitPoints = maxbarrierHitPoints;
    }
    public void GetDamage(float Damage)
    {
       barrierHitPoints -= Damage;
    }
    void Update()
    {
        if(barrierHitPoints <= 0)
        {
            barrierObj.SetActive(false);
            centerBut.SetActive(true);
            leftBut.SetActive(true);
            rightBut.SetActive(true);
            barrierHitPoints = maxbarrierHitPoints;
        }
    }
}
