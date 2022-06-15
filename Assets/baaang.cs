using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baaang : MonoBehaviour
{
    public int Pover = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.tag == "ggwp" )  
        {
            Debug.Log("EnTER");
            transform.GetComponentInParent<Enemy>().GetDamage(Pover);
        }
    }
}
