using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : IObjective
{
    public GameObject renderObject;

    public LevelStateManager levelStateManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (HasCompleted()) return;

        if (other.gameObject.tag == "Player")
        {
            renderObject.SetActive(false);
        }
    }

    public override bool HasCompleted()
    {
        return ! renderObject.activeInHierarchy;
    }
}
