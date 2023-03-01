using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baaang : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
  
    public void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "ggwp" )  
        {
            if (GunT.bullet)
            {
                GunT.bullet.SetActive(false);
                transform.GetComponentInParent<Enemy>().GetDamage(4);
            }
                
        }
        if (other.gameObject.tag == "exp")
        {
            transform.GetComponentInParent<Enemy>().GetDamage(10000);
            Destroy(other.gameObject, 0.2f);
        }*/
    }
}
