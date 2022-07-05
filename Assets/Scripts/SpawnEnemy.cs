
using System;
using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public float timeToSpawn = 10f, timeToSpawnClone = 10f;
    public GameObject[] spawnPoint;
    public GameObject enemyPoolMeles;
    public GameObject enemyPoolRanges;
    public GameObject enemyPoolNpc;
    public GameObject GameManager;
    public wave[] waves;
    public seconds[] second;
    public int WaveNomber = 0;
    public bool canSpawnM = true, canSpawnR = true, canSpawnN = true;
    public bool endOfWaveAndCanSpawnModuls = false;
    public GameObject BarCenter;
    public GameObject BarLeft;
    public GameObject BarRight;
    public float timeSp = 0f;




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
        curEnemy.gameObject.GetComponent<Enemy>().BarCenter = BarCenter;
        curEnemy.gameObject.GetComponent<Enemy>().BarRight = BarRight;
        curEnemy.gameObject.GetComponent<Enemy>().BarLeft = BarLeft;
        curEnemy.gameObject.SetActive(true);
    }
    
    void Update()
    {

        if (timeToSpawn <= 0 && waves.Length - 1 >= WaveNomber/* && timeSp <= 10f*/)
        {

            if (true)
            {
                for (int i = 1; waves[WaveNomber].meles >= i && canSpawnM /*&& second[(int)timeSp].meles >= i*/; )
                {
                    if (timeSp >=1f) {
                        SpawnM(spawnPoint, enemyPoolMeles);
                        i++;
                        if (waves[WaveNomber].meles <= i)
                            canSpawnM = false;
                    }
                }

                for (int i = 1; waves[WaveNomber].ranges >= i && canSpawnR /*&& second[(int)timeSp].ranges >= i*/; )
                {
                    if (timeSp >= 1f)
                    {
                        SpawnM(spawnPoint, enemyPoolRanges);
                        i++;
                        if (waves[WaveNomber].ranges <= i)
                            canSpawnR = false;
                    }
                }

                for (int i = 1; waves[WaveNomber].Npc >= i && canSpawnN /*&& second[(int)timeSp].Npc >= i*/; )
                {
                        if (timeSp >= 1f)
                        {
                            SpawnM(spawnPoint, enemyPoolNpc);
                            i++;
                            if (waves[WaveNomber].Npc <= i)
                                canSpawnN = false;
                        }
                } 
            }
            
            timeToSpawn = timeToSpawnClone;
            SPVD();
            if (timeSp >= 1.1f)
                timeSp = 0;


            WaveNomber++;
            canSpawnM = true;
            canSpawnR = true;
            canSpawnN = true;
            endOfWaveAndCanSpawnModuls = true;
        }
        timeToSpawn -= Time.deltaTime;
        /*timeSp += Time.deltaTime;*/
        /*timeSp += Time.deltaTime;
        if (timeSp >= 11f)
            timeSp = 0;*/
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
    [Serializable]
    public struct seconds
    {
        public float time;
        
        public int meles;
        public int ranges;
        public int Npc;
    }
}