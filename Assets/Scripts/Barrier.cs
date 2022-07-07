using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float barrierHitPoints;
    public float maxbarrierHitPoints = 40f;
    public GameObject barrierObj;
    public GameObject centerBut;
    public GameObject leftBut;
    public GameObject rightBut;
    public GameObject ff;

    public void ddd()
    {
        if (ff.GetComponent<GameManager>().Energy > 100)
        {
            ff.GetComponent<GameManager>().Energy -= 100;
            gameObject.SetActive(true);
        }
    }

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
            
            barrierHitPoints = maxbarrierHitPoints;
        }
    }
}
