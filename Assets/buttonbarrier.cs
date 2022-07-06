using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonbarrier : MonoBehaviour
{
    public GameObject BarCenter;
    public GameObject BarLeft;
    public GameObject BarRight;
    public GameObject button;
    public GameObject Gm;
    public GameObject centerBut;
    public GameObject leftBut;
    public GameObject rightBut;

    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (((other.gameObject.tag == "righthand")||(other.gameObject.tag == "lefthand")) && button.gameObject.tag == "barcentbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            if(BarCenter.activeSelf)
            {
                return;
            }
            Gm.GetComponent<GameManager>().Energy -= 100;
            centerBut.SetActive(false);
            leftBut.SetActive(false);
            rightBut.SetActive(false);
            BarCenter.SetActive(true);
        }
        if (((other.gameObject.tag == "righthand") || (other.gameObject.tag == "lefthand")) && button.gameObject.tag == "barleftbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            if (BarLeft.activeSelf)
            {
                return;
            }
            Gm.GetComponent<GameManager>().Energy -= 100;
            centerBut.SetActive(false);
            leftBut.SetActive(false);
            rightBut.SetActive(false);
            BarLeft.SetActive(true);
        }
        if (((other.gameObject.tag == "righthand") || (other.gameObject.tag == "lefthand")) && button.gameObject.tag == "barrightbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            if (BarRight.activeSelf)
            {
                return;
            }
            Gm.GetComponent<GameManager>().Energy -= 100;
            centerBut.SetActive(false);
            leftBut.SetActive(false);
            rightBut.SetActive(false);
            BarRight.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
