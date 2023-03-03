using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AnimSoundMatcher : MonoBehaviour
{
    public Enemy enemy;

    public StudioEventEmitter emitter; 

    public GameObject gg;


    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.reachedAttackDistance && emitter.IsPlaying())
        {
            emitter.Stop();
            gg.SetActive(true);
        }
    }
}
