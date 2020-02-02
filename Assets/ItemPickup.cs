﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : IObjective
{
    public GameObject renderObject;

    public LevelStateManager levelStateManager;

    public int shipPartID = -1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (HasCompleted()) return;

        if (other.gameObject.tag == "Player")
        {
            renderObject.SetActive(false);

            ProgressMonitor.EnsureInitialized();
            if (shipPartID >= 0) ProgressMonitor.progress[shipPartID] = true;
        }
    }

    public override bool HasCompleted()
    {
        return ! renderObject.activeInHierarchy;
    }
}
