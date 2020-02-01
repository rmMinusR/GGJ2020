using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRestrictor : MonoBehaviour
{
    [Tooltip("RectTransform to constrain this object to")]
    public RectTransform restriction;

    [Tooltip("How much relative acceleration is applied over time?")]
    public AnimationCurve accelerationCurve;

    [Tooltip("Scale of the repulsive force applied")]
    public float scale = 3;

    [Tooltip("Time scale factor (because the animation curve is fucky)")]
    public float timeScale = 1;

    [Tooltip("Minimum repulsive force applied per second")]
    public float minAccel = 3;

    //Measured in seconds
    private float timeSpentAccelerating;

    // Start is called before the first frame update
    void Start()
    {
        timeSpentAccelerating = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Position of this object, in 2d
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);

        //The minimum/maxmimum x/y of the constraining rectangle
        //THIS IS A KLUDGE, FIX THIS LATER
        float x1 = restriction.anchoredPosition.x - restriction.sizeDelta.x / 2;
        float x2 = restriction.anchoredPosition.x + restriction.sizeDelta.x / 2;
        float y1 = restriction.anchoredPosition.y - restriction.sizeDelta.y / 2;
        float y2 = restriction.anchoredPosition.y + restriction.sizeDelta.y / 2;

        //Apply the acceleration attempting to return the object to the bounding box?
        bool doReturnAccel = pos2d.x < x1 || pos2d.x > x2 || pos2d.y < y1 || pos2d.y > y2;

        //Track the amount of time spent accelerating towards the bounding box
        if (doReturnAccel)
        {
            timeSpentAccelerating += Time.deltaTime;
        }
        else
        {
            timeSpentAccelerating = 0;
            return;
        }

        //Closest point within the Bounding Box
        Vector2 targetPoint = new Vector2(
            Mathf.Clamp(pos2d.x, x1, x2),
            Mathf.Clamp(pos2d.y, y1, y2)
        );

        //Accelerate in the direction of the closest point of the BB
        Vector2 accel = (targetPoint - pos2d);
        //Set the minimum acceleration
        accel = accel.normalized * Mathf.Max(minAccel, accel.magnitude);
        //Accelerate according to the curve
        accel *= accelerationCurve.Evaluate(Mathf.Clamp(timeSpentAccelerating * timeScale, 0, 1)) * scale;

        if (accel.magnitude > 0.1f) {
            GetComponent<Rigidbody2D>().velocity -= (Vector2)(Time.deltaTime * Physics.gravity);
            GetComponent<Rigidbody2D>().velocity += accel;
        }

    }
}
