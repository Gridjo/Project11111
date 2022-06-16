using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcArena : Enemy
{

    void OnTriggerEnter(Collider myCollision)
    {
        if (myCollision.gameObject.tag == "MeleDistance" && gameObject.activeSelf)
        {
            EnemyDeath();
        }
    }
}
