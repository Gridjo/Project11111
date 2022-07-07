
using System;
using System.Collections;
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
    public bool canSpawnM = true, canSpawnR = true, canSpawnN = true;/*
    public bool canSpawnMA = true, canSpawnRA = true, canSpawnNA = true;*/
    public bool canSpawnAM = false, canSpawnAR = false, canSpawnAN = false;
    public bool endOfWaveAndCanSpawnModuls = false;
    public GameObject BarCenter;
    public GameObject BarLeft;
    public GameObject BarRight;
    private int iM = 1;
    private int iR = 1;
    private int iN = 1;
    private bool Stoop = false;
    public GameObject ggp;
    public GameObject ggr;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    IEnumerator Stoppp()
    {
        yield return new WaitForSeconds(1f);
        StopAllCoroutines();
    }
    IEnumerator SpawnM(GameObject[] spawnPoint, GameObject enemyPoolMeles)
    {



        canSpawnM = false;
        canSpawnR = false;
        canSpawnN = false;
        yield return new WaitForSeconds(1f);
        var curEnemy = enemyPoolMeles.transform.GetChild(0);
        curEnemy.SetParent(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Length)].transform, false);
        gameObject.transform.localPosition = new Vector3();
        curEnemy.gameObject.GetComponent<Enemy>().SpawnManager = gameObject;
        curEnemy.gameObject.GetComponent<Enemy>().BarCenter = BarCenter;
        curEnemy.gameObject.GetComponent<Enemy>().BarRight = BarRight;
        curEnemy.gameObject.GetComponent<Enemy>().BarLeft = BarLeft;
        curEnemy.gameObject.GetComponent<Enemy>().ggr = ggr;
        curEnemy.gameObject.GetComponent<Enemy>().ggp = ggp;
        curEnemy.gameObject.SetActive(true);

        canSpawnM = true;
        canSpawnR = true;
        canSpawnN = true;
        if (!Stoop)
        {
            Sppp(); 
        }

    }
    public void Sppp()
    {
        if (waves.Length - 1 >= WaveNomber && canSpawnM && canSpawnN && canSpawnR)
        {
            for (int i = 1; waves[WaveNomber].Npc >= iN && canSpawnN /*&& second[(int)timeSp].Npc >= i*/; iN++)
            {
                StartCoroutine(SpawnM(spawnPoint, enemyPoolNpc));

                if (waves[WaveNomber].Npc <= iN)
                {/*
                    canSpawnNA = false;*/
                    canSpawnAN = true;
                }

            }
            for (int i = 0; waves[WaveNomber].meles >= iM && canSpawnM; iM++)
            {
                StartCoroutine(SpawnM(spawnPoint, enemyPoolMeles));

                if (waves[WaveNomber].meles <= iM)
                {/*
                    canSpawnMA = false;*/
                    canSpawnAM = true;
                }
            }

            for (int i = 1; waves[WaveNomber].ranges >= iR && canSpawnR /*&& second[(int)timeSp].ranges >= i*/; iR++)
            {
                StartCoroutine(SpawnM(spawnPoint, enemyPoolRanges));

                if (waves[WaveNomber].ranges <= iR)
                {/*
                    canSpawnRA = false;*/
                    canSpawnAR = true;
                }
            }

            

            if (canSpawnAM && canSpawnAN && canSpawnAR)
            {
                StartCoroutine(Stoppp());
                Stoop = true;
                timeToSpawn = timeToSpawnClone;
                WaveNomber++;
                canSpawnM = true;
                canSpawnR = true;
                canSpawnN = true;
                canSpawnAM = false;
                canSpawnAR = false;
                canSpawnAN = false;

                iN = 1;
                iR = 1;
                iM = 1;
                
                /*StopAllCoroutines();*/
                return;
            }
            /*if (!canSpawnMA && !canSpawnNA && !canSpawnRA)
            {

            }*/
            SPVD();
        }

    }

    void Update()
    {

        if (timeToSpawn <= 0)
        {
            Sppp();


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