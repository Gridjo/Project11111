using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public GameObject enemyPool;

    void OnEnable()
    {
        // ��������� ���������� ������
        UnityEngine.AI.NavMeshAgent agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // ������� ����� ����������
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision myCollision)
    {
        // ����������� ������������ � ����� ������������� ���������
        if (myCollision.gameObject.tag == "Platforrm" && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(enemyPool.transform, false);
            gameObject.transform.localPosition = new Vector3();
            Debug.Log("spawn " + gameObject.name);

        }
        
    }
}

