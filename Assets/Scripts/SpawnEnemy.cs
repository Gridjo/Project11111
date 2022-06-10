
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float timeToSpawn = 10f, timeToSpawnClone = 10f;
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
    public void SpawnMele(GameObject[] spawnPoint, GameObject enemyPoolMeles)
    {
        var curEnemy = enemyPoolMeles.transform.GetChild(0);
        curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
        gameObject.transform.localPosition = new Vector3();
        curEnemy.gameObject.SetActive(true);
    }
    public void SpawnRange(GameObject[] spawnPoint, GameObject enemyPoolRange)
    {
        var curEnemy = enemyPoolRange.transform.GetChild(0);
        curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
        gameObject.transform.localPosition = new Vector3();
        curEnemy.gameObject.SetActive(true);
    }
    void Update()
    {

        if (timeToSpawn <= 0 && waves.Length - 1 >= WaveNomber)
        {

            for (int i = 0; waves[WaveNomber].meles >= i; i++)
            {
                SpawnMele(spawnPoint, enemyPoolMeles);
            }

            for (int i = 0; waves[WaveNomber].ranges >= i; i++)
            {
                SpawnRange(spawnPoint, enemyPoolRanges);
            }
            timeToSpawn = timeToSpawnClone;
            WaveNomber++;
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