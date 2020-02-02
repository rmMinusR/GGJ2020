using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableSoundPlayer : ITriggerSubscriber
{
    public AudioSource source;

    public AudioClip[] sounds;

    public TriggerMode triggerMode = TriggerMode.ANY;

    public override void OnTriggerChange(ITrigger t) {

        bool shouldTriggerSound = !source.isPlaying;
        if (!shouldTriggerSound) return;

        switch(triggerMode)
        {
            case TriggerMode.RISING:
                if (t.GetState()) shouldTriggerSound = false;
                break;
            case TriggerMode.FALLING:
                if (!t.GetState()) shouldTriggerSound = false;
                break;
        }

        if (shouldTriggerSound)
        {
            source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
        }
    }
}
