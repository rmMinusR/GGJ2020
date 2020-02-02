using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITriggerSubscriber : MonoBehaviour {
    public ITrigger trigger;

    public abstract void OnTriggerChange(ITrigger t);
}
