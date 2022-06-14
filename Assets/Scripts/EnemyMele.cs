using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMele : Enemy
{
    
    void OnTriggerEnter(Collider myCollision)
    {

        OnCollisionMele(myCollision);

    }
}
