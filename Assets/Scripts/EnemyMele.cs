using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMele : Enemy
{

    void OnTriggerEnter(Collider myCollision)
    {

        OnCollisionMele(myCollision);

    }
    
    void OnEnable()
    {
        // Получение компонента агента
        NavMeshAgent agent
            = GetComponent<NavMeshAgent>();
        // Указаие точки назначения
        agent.destination = goal.position;
        agent.speed = EnemySpeed;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        curHeetPoint = maxHeetPoint;
        gameObject.GetComponent<Animator>().SetInteger("State", 0);
    }
    void Update()
    {
        if (reachedAttackDistance)
        {
            if (timeToAtack <= 0)
            {
                GiveDamage(goal);
                timeToAtack = timeToAtackClone;
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
            timeToAtack -= Time.deltaTime;
        }
        if (curHeetPoint <= 0)
        {
            EnemyDeath();
        }
    }
}
