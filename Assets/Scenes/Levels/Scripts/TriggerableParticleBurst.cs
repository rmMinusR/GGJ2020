using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class TriggerableParticleBurst : ITriggerSubscriber
{
    public TriggerMode triggerMode = TriggerMode.ANY;

    public override void OnTriggerChange(ITrigger t)
    {

        bool shouldTrigger = true;

        switch (triggerMode)
        {
            case TriggerMode.RISING:
                if (t.GetState()) shouldTrigger = false;
                break;
            case TriggerMode.FALLING:
                if (!t.GetState()) shouldTrigger = false;
                break;
        }

        if (shouldTrigger)
        {
            GetComponent<ParticleSystem>().Clear();
            GetComponent<ParticleSystem>().Play();
        }
    }
}
