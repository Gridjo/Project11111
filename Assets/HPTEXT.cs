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
        texthp.text = "HP : " + hp;
        textenergy.text = "ENERGY : " + energy;
        textscore.text = "SCORE : " + score;
    }

    void Update()
    {
        hp = Pl.GetComponent<Platform>().HeetPoints;
        energy = Gm.GetComponent<GameManager>().Energy;
        score = Gm.GetComponent<GameManager>().ScoreReiting;
        en = (int)energy;
        texthp.text = "HP : " + hp;
        textenergy.text = "ENERGY : " + en;
        textscore.text = "SCORE : " + score;
    }
}
