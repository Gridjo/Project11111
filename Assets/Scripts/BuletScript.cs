using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletScript : MonoBehaviour
{
    public Transform Platform;
    public float timeToDestroy = 3f;
    public float AtackDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
        timeToDestroy -= Time.deltaTime;
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MeleDistance")
        {
            Platform.gameObject.GetComponent<Platform>().GetDamage(AtackDamage);
            Destroy(this.gameObject);
 
        }
        
    }
}
