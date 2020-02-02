using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneGravity : MonoBehaviour
{
    [Tooltip("How does the gravity fall off?")]
    public AnimationCurve falloffCurve = AnimationCurve.Linear(0, 1, 1, 0);

    [Tooltip("How far should the maximum falloff distance be?")]
    public float falloffMaxDist;

    [Tooltip("Gravity to replace this with")]
    public Vector2 gravity;

    void Update() {} //Exists only for the checkbox

    void OnTriggerStay2D(Collider2D other)
    {
        if (!gameObject.activeInHierarchy) return;

        //Position of this object, in 2d
        Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);

        Rigidbody2D rb;
        if ((rb = other.gameObject.GetComponent<Rigidbody2D>()) != null)
        {
            //Calculate the normalized falloff
            float falloffNrm = falloffCurve.Evaluate(
                    (other.ClosestPoint(pos2d) - pos2d).magnitude * falloffMaxDist
                );

            //Replace gravity with what we want
            rb.velocity += (gravity - (Vector2)Physics.gravity) * falloffNrm * Time.deltaTime;
        }
    }
}
