using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMele : Enemy
{
    public float[] hp = { 15f, 21f, 28f, 34f, 41f, 48f, 54f, 61f, 67f, 74f };
    public int[] sc = { 12, 20, 25, 30, 35, 40, 47, 52, 57, 62 };

    void OnTriggerEnter(Collider myCollision)
    {

        OnCollisionMele(myCollision);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            
            Debug.Log("EnTER");
            GetDamage(100);
            Destroy(collision.gameObject);
        }
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
        reachedAttackDistance = false;
        maxHeetPoint = hp[SpawnManager.GetComponent<SpawnEnemy>().WaveNomber];
        curHeetPoint = maxHeetPoint;
        ScorePoint = sc[SpawnManager.GetComponent<SpawnEnemy>().WaveNomber];
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
            if (!reachedAttackDistance)
                GameManager1.transform.GetComponent<GameManager>().GetScore((int)(ScorePoint * 1.1));
            else
                GameManager1.transform.GetComponent<GameManager>().GetScore((int)(ScorePoint));
            EnemyDeath();
        }
    }
}
