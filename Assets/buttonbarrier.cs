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
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ggwp" && button.gameObject.tag == "barcentbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            Gm.GetComponent<GameManager>().Energy -= 100;
            BarCenter.SetActive(true);
        }
        if (other.gameObject.tag == "ggwp" && button.gameObject.tag == "barleftbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            Gm.GetComponent<GameManager>().Energy -= 100;
            BarLeft.SetActive(true);
        }
        if (other.gameObject.tag == "ggwp" && button.gameObject.tag == "barrightbut" && (Gm.GetComponent<GameManager>().Energy >= 100))
        {
            Gm.GetComponent<GameManager>().Energy -= 100;
            BarRight.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
