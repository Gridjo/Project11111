using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public float Energy = 0, MaxEnergy = 100;
    public float EnergyMultiplier = 1;
    private float TimeEner = 1f, TimeEnerOut = 1f;
    public GameObject ModulPool;
    public GameObject[] Childs;
    public GameObject[] ModSp;
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
    public void SpawnModul()
    {

        ModSp = null;
        float ScoreWaveMod = Score * 0.8f;
        float ScoreJunk = Score - ScoreWaveMod;
        for (int i = 0; i < ModulPool.transform.childCount; i++)
        {
            Childs[i] = ModulPool.transform.GetChild(i).gameObject;
        }
        for (int i = 0, j=0; i < Childs.Length; i++)
        {
            if (ScoreWaveMod > Childs[i].GetComponent<Moduls>().junkPrice)
            {
                ModSp[j] = Childs[i];
            }
        }
        for (int i = 0, j = 0; i < ModSp.Length; i++)
        {

        }
    }
}
