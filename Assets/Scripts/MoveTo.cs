using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public GameObject enemyPool;

    void OnEnable()
    {
        // Получение компонента агента
        NavMeshAgent agent
            = GetComponent<NavMeshAgent>();
        // Указаие точки назначения
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision myCollision)
    {
        // определение столкновения с двумя разноименными объектами
        if (myCollision.gameObject.tag == "MeleDistance" && gameObject.activeSelf && this.gameObject.tag == "MeleEntity")
        {
            /*gameObject.SetActive(false);
            gameObject.transform.SetParent(enemyPool.transform, false);
            gameObject.transform.localPosition = new Vector3();
            Debug.Log("spawn " + gameObject.name);*/
            myCollision.gameObject.transform.parent.gameObject.GetComponent<Platform>().HeetPoints -= 1;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }
        if (myCollision.gameObject.tag == "RangeGistance" && gameObject.activeSelf && this.gameObject.tag == "MeleEntity")
        {
            Physics.IgnoreCollision(myCollision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (myCollision.gameObject.tag == "RangeGistance" && gameObject.activeSelf && this.gameObject.tag == "RangeEntity")
        {
            /*gameObject.SetActive(false);*/
            /*gameObject.GetComponent<NavMeshAgent>().enabled = false;*/
            /*gameObject.transform.SetParent(enemyPool.transform, false);
            gameObject.transform.localPosition = new Vector3();
            Debug.Log("spawn " + gameObject.name);*/
            myCollision.gameObject.transform.parent.gameObject.GetComponent<Platform>().HeetPoints -= 1;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }

    }
}

