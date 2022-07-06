using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AnimSoundMatcher : MonoBehaviour
{
    public Enemy enemy;

    private StudioEventEmitter emitter;


    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.reachedAttackDistance == true && emitter.IsPlaying())
        {
            emitter.Stop();
        }
    }
}
