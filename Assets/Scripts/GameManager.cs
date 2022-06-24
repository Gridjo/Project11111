using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Score = 0;
    public float Energy = 0, MaxEnergy = 500;
    public float EnergyMultiplier = 1;
    private float TimeEner = 1f, TimeEnerOut = 1f;
    public GameObject ModulPool;
    public GameObject[] Childs;
    public GameObject[] ModSp;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Energy < MaxEnergy)
        {
            if (TimeEner <= 0)
            {

                Energy += 1 * EnergyMultiplier;
                TimeEner = TimeEnerOut;
            }
            TimeEner -= Time.deltaTime;
        }
        if (Energy > MaxEnergy)
        {
            Energy = MaxEnergy;
        }
    }
    public void GetScore(int ScoreIn)
    {
        Score += ScoreIn;
    }
    public void MinusScore(int ScoreIn)
    {
        Score -= ScoreIn;
    }
    public void EnerMult(float mult)
    {
        Debug.Log("Lj,fdktybt");
        EnergyMultiplier += mult;
    }
    public void ChSpawnModul()
    {
        Debug.Log("ffggg1");
        Childs = new GameObject[ModulPool.transform.childCount];
        ModSp = null;
        float ScoreWaveMod = Score * 0.8f;
        Score *= 0.8f;
        if (Score < 14f)
        {
            return;
        }
        float ScoreJunk = Score - ScoreWaveMod;
        for (int i = 0; i < ModulPool.transform.childCount;  i++)
        {
            Debug.Log(ModulPool.transform.GetChild(i).gameObject.name);
            Childs[i] = ModulPool.transform.GetChild(i).gameObject;
            Debug.Log(Childs[i].name);
        }
        ModSp = new GameObject[Childs.Length];
        for (int i = 0, j=0; i < Childs.Length; i++)
        {
            if (ScoreWaveMod > Childs[i].GetComponent<Moduls>().junkPrice)
            {
                ModSp[j] = Childs[i];
                j++;
            }
        }
        int rr = UnityEngine.Random.Range(0, 100);
        for (int i = 0; i < ModSp.Length; i++)
        {
            
            if (rr < 50)
            {
                if (ModSp[i].TryGetComponent<Moduls>(out Moduls cc))
                {
                    if (cc.Raryti == Rarity.Common)
                    {
                        SpawnModul(ModSp[i]);
                        return;
                    } 
                }
            }
            else if(rr < 80)
            {
                if (ModSp[i].TryGetComponent<Moduls>(out Moduls cc))
                {
                    if (cc.Raryti == Rarity.Rare)
                    {
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
            else if (rr < 95)
            {
                if (ModSp[i].TryGetComponent<Moduls>(out Moduls cc))
                {
                    if (cc.Raryti == Rarity.Epic)
                    {
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
            else if (rr < 100)
            {
                if (ModSp[i].TryGetComponent<Moduls>(out Moduls cc))
                {
                    if (cc.Raryti == Rarity.Legendary)
                    {
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
              
        }
        
    }
    public void SpawnModul(GameObject Mod)
    {

        Mod.transform.SetParent(spawnPoint.transform, false);
        Mod.transform.position = new Vector3();
        Mod.transform.localPosition = new Vector3();
        Mod.SetActive(true);
        ChSpawnModul();
    }
}
