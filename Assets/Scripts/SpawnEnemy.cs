using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float timeToSpawn = 5f;
    public int SpawnCount = 1;
    public GameObject enemyPref;
    public GameObject[] spawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn<=0)
        {
            StartCoroutine(SpawnWREnemy());
            timeToSpawn = 4;
        }
        timeToSpawn -= Time.deltaTime;
        
    }
    IEnumerator SpawnWREnemy()
    {
        for (int i = 0;  SpawnCount >= i; i++)
        {
            

            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(spawnPoint[Random.Range(0, spawnPoint.Length)].transform, false);
            

            yield return new WaitForSeconds(1f);
        }
    }
}
