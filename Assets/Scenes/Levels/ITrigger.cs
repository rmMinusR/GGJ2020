using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITrigger : MonoBehaviour
{
    private void BroadcastChange()
    {
        foreach(ITriggerSubscriber sub in Object.FindObjectsOfType<ITriggerSubscriber>())
        {

        }
    }

    public abstract bool GetState();
}
