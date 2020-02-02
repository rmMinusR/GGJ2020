using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRestrictor : MonoBehaviour
{
    [Tooltip("Collider (TRIGGER) to constrain this object to")]
    public Collider2D restriction;

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

        //Point closest to this object
        Vector2 closest = restriction.ClosestPoint(pos2d);

        //Apply the acceleration attempting to return the object to the collider
        bool doReturnAccel = (pos2d - closest).magnitude > 0.1f;

        //Track the amount of time spent accelerating towards the collider
        if (doReturnAccel)
        {
            timeSpentAccelerating += Time.deltaTime;
        }
        else
        {
            timeSpentAccelerating = 0;
            return;
        }

        //Accelerate in the direction of the closest point of the BB
        Vector2 accel = (closest - pos2d);
        //Set the minimum acceleration
        accel = accel.normalized * Mathf.Max(minAccel, accel.magnitude);
        //Accelerate according to the curve
        accel *= accelerationCurve.Evaluate(Mathf.Clamp(timeSpentAccelerating * timeScale, 0, 1)) * scale;

        if (accel.magnitude > 0.1f)
        {
            GetComponent<Rigidbody2D>().velocity -= (Vector2)(Time.deltaTime * Physics.gravity);
            GetComponent<Rigidbody2D>().velocity += accel;
        }

    }
}
