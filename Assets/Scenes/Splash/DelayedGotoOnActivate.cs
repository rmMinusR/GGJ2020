using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedGotoOnActivate : MonoBehaviour
{
    public float delay = 1f;

    public Object scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedGoto());
    }

    IEnumerator DelayedGoto()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene.name);
    }
}
