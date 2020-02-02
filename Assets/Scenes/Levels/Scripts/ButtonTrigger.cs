using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ButtonTrigger : ITrigger
{
    public bool invert = false;
    public override bool GetState()
    {
        return objectsInTrigger.Count <= 0;
    }

    private List<GameObject> objectsInTrigger = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!objectsInTrigger.Contains(other.gameObject) && other.gameObject.tag == "Player") objectsInTrigger.Add(other.gameObject);
        DoBroadcastChange();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(objectsInTrigger.Contains(other.gameObject)) objectsInTrigger.Remove(other.gameObject);
        DoBroadcastChange();
    }
}
