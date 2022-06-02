using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : MonoBehaviour
{

    public GameObject holder;
    public Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*tr.position.Set(0,0,0);*/
    }

    
}
