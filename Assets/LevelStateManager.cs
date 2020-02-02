using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStateManager : MonoBehaviour
{
    public List<IObjective> objectives;

    public Object levelHub;

    // Start is called before the first frame update
    void Start()
    {
        objectives = new List<IObjective>(Object.FindObjectsOfType<IObjective>());
    }

    // Update is called once per frame
    void Update()
    {
        bool hasFinishedLevel = true;
        foreach(IObjective o in objectives)
        {
            hasFinishedLevel = hasFinishedLevel && o.HasCompleted();
        }

        if(hasFinishedLevel)
        {
            SceneManager.LoadScene(levelHub.name);
        }
    }
}

public abstract class IObjective : MonoBehaviour
{
    public abstract bool HasCompleted();
}
