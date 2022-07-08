using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPTEXT : MonoBehaviour
{
    public Text texthp;
    public Text textenergy;
    public Text textscore;
    public float hp;
    public float energy;
    public float score;
    private int en;
    public GameObject Pl;
    public GameObject Gm;

    void Start()
    {
        hp = Pl.GetComponent<Platform>().HeetPoints;
        energy = Gm.GetComponent<GameManager>().Energy;
        score = Gm.GetComponent<GameManager>().ScoreReiting;
        texthp.text = "HP : " + (int)hp;
        textenergy.text = "ENERGY : " + (int)energy;
        textscore.text = "SCORE : " + (int)score;
    }

    void Update()
    {
        hp = Pl.GetComponent<Platform>().HeetPoints;
        energy = Gm.GetComponent<GameManager>().Energy;
        score = Gm.GetComponent<GameManager>().ScoreReiting;
        en = (int)energy;
        texthp.text = "HP : " + (int)hp;
        textenergy.text = "ENERGY : " + (int)en;
        textscore.text = "SCORE : " + (int)score;
    }
}
