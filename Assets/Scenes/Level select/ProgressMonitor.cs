using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressMonitor : MonoBehaviour
{
    public static bool[] progress;
    private static bool hasBeenInitialized = false;

    public ProgressIndicator[] objectivePieces;

    public GameObject completionMessage;

    private void Start()
    {
        if (FindObjectsOfType<ProgressMonitor>().Length > 1)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            progress = new bool[objectivePieces.Length];
            DontDestroyOnLoad(this);
        }

        EnsureInitialized();
    }

    public static void EnsureInitialized()
    {
        if (!hasBeenInitialized)
        {
            for (int i = 0; i < progress.Length; i++)
            {
                progress[i] = false;
            }
            hasBeenInitialized = true;
        }
    }

    private void Update()
    {
        bool isComplete = true;
        for (int i = 0; i < objectivePieces.Length; i++)
        {
            objectivePieces[i].SetState(progress[i]);
            if (!progress[i]) isComplete = false;
        }

        completionMessage.SetActive(isComplete);
    }
}
