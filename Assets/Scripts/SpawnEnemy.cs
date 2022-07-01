
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
    public GameObject enemyPoolNpc;
    public GameObject GameManager;
    public wave[] waves;
    public int WaveNomber = 0;
    public bool canSpawnM = true, canSpawnR = true, canSpawnN = true;
    public bool endOfWaveAndCanSpawnModuls = false;
    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SpawnM(GameObject[] spawnPoint, GameObject enemyPoolMeles)
    {
        var curEnemy = enemyPoolMeles.transform.GetChild(0);
        curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
        gameObject.transform.localPosition = new Vector3();
        curEnemy.gameObject.GetComponent<Enemy>().SpawnManager = gameObject;
        curEnemy.gameObject.SetActive(true);
    }
    
    void Update()
    {

        if (timeToSpawn <= 0 && waves.Length - 1 >= WaveNomber)
        {

            for (int i = 1; waves[WaveNomber].meles >= i && canSpawnM; i++)
            {
                SpawnM(spawnPoint, enemyPoolMeles);
                if (waves[WaveNomber].meles <= i)
                    canSpawnM = false;
            }

            for (int i = 1; waves[WaveNomber].ranges >= i && canSpawnR; i++)
            {
                SpawnM(spawnPoint, enemyPoolRanges);
                if (waves[WaveNomber].ranges <= i)
                    canSpawnR = false;
            }

            for (int i = 1; waves[WaveNomber].Npc >= i && canSpawnN; i++)
            {
                SpawnM(spawnPoint, enemyPoolNpc);
                if (waves[WaveNomber].Npc <= i)
                    canSpawnN = false;
            }
            timeToSpawn = timeToSpawnClone;
            SPVD();


            Debug.Log("ffggg");

            WaveNomber++;
            canSpawnM = true;
            canSpawnR = true;
            canSpawnN = true;
            endOfWaveAndCanSpawnModuls = true;
        }
        timeToSpawn -= Time.deltaTime;
    }
    void SPVD()
    { 
        try
        {
            GameManager.GetComponent<GameManager>().ChSpawnModul();
            GameManager.GetComponent<GameManager>().CountVis = 0;
        }
        catch (NullReferenceException e)
        {
            SPVD();
        }
    }

    [Serializable]
    public struct wave
    {
        public int meles;
        public int ranges;
        public int Npc;
    }
}