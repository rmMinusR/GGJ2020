using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressMonitor : MonoBehaviour
{
    public static bool[] progress;
    private static bool hasBeenInitialized = false;

    public GameObject[] objectivePieces;

    public GameObject completionMessage;

    private void Start()
    {
        if(!hasBeenInitialized)
        {
            progress = new bool[objectivePieces.Length];
            for(int i = 0; i < objectivePieces.Length; i++)
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
            objectivePieces[i].SetActive(progress[i]);
            if (!progress[i]) isComplete = false;
        }

        completionMessage.SetActive(isComplete);
    }
}
