using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableVanish : ITriggerSubscriber
{
    public GameObject door;

    public override void OnTriggerChange()
    {
        door.SetActive(trigger.GetState());
    }
}
