using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcArena : Enemy
{
    public float mult = 0.1f;
    void OnTriggerEnter(Collider myCollision)
    {
        if (myCollision.gameObject.tag == "MeleDistance" && gameObject.activeSelf)
        {
            Debug.Log("ВЫзов функции");
            GameManager1.transform.GetComponent<GameManager>().EnerMult(mult);
            EnemyDeath();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ggwp")
        {
            GameManager1.transform.GetComponent<GameManager>().MinusScore((ScorePoint));
            Debug.Log("EnTER");
            GetDamage(100);
        }
    }
}
