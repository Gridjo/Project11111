using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AnimSoundMatcher : MonoBehaviour
{
    public Enemy enemy;

    public StudioEventEmitter emitter;


    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.reachedAttackDistance == true && emitter.IsPlaying())
        {
            emitter.Stop();
            emitter.enabled = true;
        }
    }
}
