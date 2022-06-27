using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    public int AttackDamage = 1;
    public float EnemySpeed = 3.5f;
    public float timeToAtack = 1f, timeToAtackClone = 1f;
    public float curHeetPoint = 100, maxHeetPoint = 100;

    public Transform goal;
    public GameObject enemyPool;
    public bool reachedAttackDistance = false;
    public GameObject GameManager1;
    public int ScorePoint = 10;


    void OnEnable()
    {
        
        NavMeshAgent agent
            = GetComponent<NavMeshAgent>();
        
        agent.destination = goal.position;
        agent.speed = EnemySpeed;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        curHeetPoint = maxHeetPoint;
        reachedAttackDistance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedAttackDistance)
        {
            if (timeToAtack <= 0)
            {
                GiveDamage(goal);
                timeToAtack = timeToAtackClone;
            }
            timeToAtack -= Time.deltaTime;
        }
        if (curHeetPoint <= 0)
        {
            EnemyDeath();
        }

    }
    public void Stop()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;

    }
    private void Start()
    {

    }



    public void GiveDamage(Transform target)
    {
        goal.gameObject.GetComponent<Platform>().GetDamage(AttackDamage);

    }
    public void GetDamage(int Damage)
    {
        curHeetPoint -= Damage;
    }
    public void EnemyDeath()
    {
        curHeetPoint = maxHeetPoint;
        
        gameObject.SetActive(false);
        gameObject.transform.SetParent(enemyPool.transform, false);
        gameObject.transform.localPosition = new Vector3();
    }
    public void OnCollisionMele(Collider myCollision)
    {
        if (myCollision.gameObject.tag == "MeleDistance" && gameObject.activeSelf && gameObject.tag == "MeleEntity")
        {
            Stop();
            reachedAttackDistance = true;
        }
    }

    public void OnCollisionRange(Collider myCollision)
    {
        if (myCollision.gameObject.tag == "RangeGistance" && gameObject.activeSelf && this.gameObject.tag == "RangeEntity")
        {
            Stop();
            reachedAttackDistance = true;
        }
    }
}


