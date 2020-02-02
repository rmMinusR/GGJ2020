using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITrigger : MonoBehaviour
{
    protected void DoBroadcastChange()
    {
        foreach(ITriggerSubscriber sub in Object.FindObjectsOfType<ITriggerSubscriber>())
        {
            if(sub.trigger == this) sub.OnTriggerChange();
        }
    }

    public abstract bool GetState();
}
