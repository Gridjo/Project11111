using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Score = 0;
    public float Energy = 0, MaxEnergy = 500;
    public float EnergyMultiplier = 1, ScoreWaveMod = 0, CountVis = 0;
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
        EnergyMultiplier += mult;
    }
    public void ChSpawnModul()
    {
        Childs = new GameObject[ModulPool.transform.childCount];
        ModSp = null;
        ScoreWaveMod += Score * 0.8f;
        float ScoreJunk = Score - ScoreWaveMod;
        
        
        if(CountVis == 0 && ScoreJunk > 0)
        {
            Score = 0;
            RecyclerItem costil = new RecyclerItem();
            costil.RecyclerCost = (int)ScoreJunk;
            PlayerVariables.Instance.AddScraps(costil);
            ScoreJunk = 0;
        }
        CountVis++;
        if (ScoreWaveMod < 14f)
        {
            return;
        }
        
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
                if (ModSp[i].TryGetComponent(out Moduls ccc))
                {
                    if (ccc.Raryti == Rarity.Common)
                    {
                        ScoreWaveMod -= ccc.junkPrice;
                        SpawnModul(ModSp[i]);
                        return;
                    } 
                }
            }
            else if(rr < 80)
            {
                if (ModSp[i].TryGetComponent(out Moduls ccr))
                {
                    if (ccr.Raryti == Rarity.Rare)
                    {
                        ScoreWaveMod -= ccr.junkPrice;
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
            else if (rr < 95)
            {
                if (ModSp[i].TryGetComponent(out Moduls cce))
                {
                    if (cce.Raryti == Rarity.Epic)
                    {
                        ScoreWaveMod -= cce.junkPrice;
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
            else if (rr < 100)
            {
                if (ModSp[i].TryGetComponent(out Moduls ccl))
                {
                    if (ccl.Raryti == Rarity.Legendary)
                    {
                        ScoreWaveMod -= ccl.junkPrice;
                        SpawnModul(ModSp[i]);
                        return;
                    }
                }
            }
            else
            {
                ChSpawnModul();
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
