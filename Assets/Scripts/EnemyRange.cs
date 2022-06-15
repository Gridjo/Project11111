using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : Enemy
{
    public GameObject bullet;
    public float BuletSpeed = 1000f;

    public Transform Pivot;



    void Update()
    {
        if (reachedAttackDistance)
        {
            if (timeToAtack <= 0)
            {
                /*GiveDamage(goal);*/
                RangeAtack();
                timeToAtack = timeToAtackClone;
            }
            timeToAtack -= Time.deltaTime;
        }
        if (curHeetPoint <= 0)
        {
            EnemyDeath();
        }

    }

    void RangeAtack()
    {
        Pivot = gameObject.transform.GetChild(0);
        var curEnemy = Instantiate(bullet, Pivot.position, Pivot.rotation);
        curEnemy.GetComponent<BuletScript>().Platform = goal; 
        /*curEnemy.transform.SetParent(gameObject.transform, false);
        
        curEnemy.transform.localPosition = new Vector3(0,0,1.5f);*/
        curEnemy.gameObject.SetActive(true);
        curEnemy.gameObject.GetComponent<Rigidbody>().AddForce(Pivot.forward * BuletSpeed);
    }
    void OnTriggerEnter(Collider myCollision) 
    {
        OnCollisionRange(myCollision);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            GetDamage(100);
        }
    }
}
