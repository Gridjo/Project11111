using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float timeToSpawn = 2f, timeToSpawnClone = 2f;
    public GameObject[] spawnPoint;
    public GameObject enemyPoolMeles;
    public GameObject enemyPoolRanges;
    public wave[] waves;
    private int WaveNomber = 0;

   



    // Start is called before the first frame update
    void Start()
    {
         
         
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeToSpawn <= 0 && waves.Length >= WaveNomber)
        {

            for (int i = 0; waves[WaveNomber].meles >= i; i++)
            {
                var curEnemy = enemyPoolMeles.transform.GetChild(0);
                curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
                curEnemy.gameObject.SetActive(true);

            }

            for (int i = 0; waves[WaveNomber].ranges >= i; i++)
            {
                var curEnemy = enemyPoolRanges.transform.GetChild(0);
                curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
                curEnemy.gameObject.SetActive(true);
            }
            timeToSpawn = timeToSpawnClone;
            k++;
        }
        timeToSpawn -= Time.deltaTime;
    }

    [Serializable]
    public struct wave  
    {
        public int meles;
        public int ranges;
    }
}
