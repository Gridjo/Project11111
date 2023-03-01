using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBAR : MonoBehaviour
{
    public GameObject Plat;
    public Platform platform;
    public GameObject Bar;
    public GameObject Bar1;
    public GameObject Bar2;
    public void Start()
    {
        platform = Plat.GetComponent<Platform>();
    }
    public void Update()
    {
        Bar.transform.localScale = new Vector3(platform.HeetPoints/100,0.04f,0.02f);
        Bar1.transform.localScale = new Vector3(platform.HeetPoints / 100, 0.04f, 0.02f);
        Bar2.transform.localScale = new Vector3(platform.HeetPoints / 100, 0.04f, 0.02f);
    }
}
