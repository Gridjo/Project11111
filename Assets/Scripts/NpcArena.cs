using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcArena : Enemy
{
    public float mult = 0.1f;
    public bool WasDamaget = false;
    void OnEnable()
    {

        NavMeshAgent agent
            = GetComponent<NavMeshAgent>();

        agent.destination = goal.GetChild(9).position;
        agent.speed = EnemySpeed;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        curHeetPoint = maxHeetPoint;
        reachedAttackDistance = false;

    }
    void OnTriggerEnter(Collider myCollision)
    {
        if (myCollision.gameObject.name == "hatch" && gameObject.activeSelf)
        {
            GameManager1.transform.GetComponent<GameManager>().EnerMult(mult);
            EnemyDeath();
        }
        if (myCollision.gameObject.tag == "ggwp")
        {

            GetDamage(100);
            WasDamaget = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            
            GetDamage(100);
            WasDamaget = true;
        }
    }
}
