using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(LineRenderer))]
public class TimedZoneEventTrigger : MonoBehaviour
{
    public UnityEvent triggeredEvent;

    public float timeToTrigger = 3f;
    public float timeToDeplete = 1f;

    public float progress = 0;
    public float radius = 10f;

    void Update()
    {
        if(objectsInTrigger.Count > 0)
        {
            progress += Time.deltaTime / timeToTrigger;
        } else
        {
            progress -= Time.deltaTime / timeToDeplete;
        }
        progress = Mathf.Clamp(progress, 0, 1);

        Vector3[] arc = new Vector3[(int)(progress*50)];
        for(int i = 0; i < arc.Length; i++)
        {
            arc[i] = (
                    transform.right * Mathf.Cos(Mathf.PI * 2 * progress * ((float)i)/arc.Length) +
                    transform.up    * Mathf.Sin(Mathf.PI * 2 * progress * ((float)i)/arc.Length)
                ) * radius + transform.position;
        }
        GetComponent<LineRenderer>().positionCount = arc.Length;
        GetComponent<LineRenderer>().SetPositions(arc);

        if (progress >= 1) triggeredEvent.Invoke();
    }


    private List<GameObject> objectsInTrigger = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectsInTrigger.Contains(other.gameObject) && other.gameObject.tag == "Player") objectsInTrigger.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (objectsInTrigger.Contains(other.gameObject)) objectsInTrigger.Remove(other.gameObject);
    }
}
