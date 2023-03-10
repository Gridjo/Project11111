using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRange : Enemy
{
    public GameObject bullet;
    public float BuletSpeed = 1000f;

    public Transform Pivot;

    public float[] hp = { 9f, 13f, 17f, 21f, 25f, 29f, 33f, 37f, 41f, 45f };
    public int[] sc = { 7, 12, 15, 17, 22, 25, 27, 32, 35, 37 };

    void OnEnable()
    {

        NavMeshAgent agent
            = GetComponent<NavMeshAgent>();

        agent.destination = goal.position;
        agent.speed = 2f;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        curHeetPoint = maxHeetPoint;
        reachedAttackDistance = false;
        maxHeetPoint = hp[SpawnManager.GetComponent<SpawnEnemy>().WaveNomber];
        curHeetPoint = maxHeetPoint;
        ScorePoint = sc[SpawnManager.GetComponent<SpawnEnemy>().WaveNomber];
    }
    void Update()
    {
        if (reachedAttackDistance)
        {
            if (gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().isActiveAndEnabled)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            }
            if (timeToAtack <= 0)
            {
                /*GiveDamage(goal);*/
                transform.LookAt(goal);
                RangeAtack();
                timeToAtack = timeToAtackClone;
            }
            timeToAtack -= Time.deltaTime;
        }
        if (curHeetPoint <= 0)
        { 
            EnemyDeath();
            if(!reachedAttackDistance)
                GameManager1.transform.GetComponent<GameManager>().GetScore((int)(ScorePoint * 1.1));
            else
                GameManager1.transform.GetComponent<GameManager>().GetScore((int)(ScorePoint));
            EnemyDeath();
        }
        Uron = (int)(ggp.GetComponent<ModulAllInGun>().damage + ggr.GetComponent<ModulAllInGun>().damage);

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
        
        if (collision.gameObject.tag == "ggwp")
        {
            Debug.Log("EnTER");
            GetDamage(Uron);
        }

    }
}
