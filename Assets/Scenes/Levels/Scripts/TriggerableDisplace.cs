using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDisplace : ITriggerSubscriber
{
    public GameObject door;
    public Vector2 displacement;

    public AnimationCurve slideOpenAnimation = AnimationCurve.Linear(0, 0, 1, 1);

    public float slideOpenTime;
    private float animationProgress;

    private Vector2 startingPosition;
    void Start()
    {
        startingPosition = door.transform.position;
        animationProgress = 0;
    }

    void Update()
    {
        //Do animation
        if(trigger.GetState())
        {
            animationProgress += Time.deltaTime / slideOpenTime;
        } else
        {
            animationProgress -= Time.deltaTime / slideOpenTime;
        }
        //Clamp to M:[0,1]
        animationProgress = Mathf.Clamp(animationProgress, 0, 1);

        //Calculate the door's position
        door.transform.position = startingPosition + displacement * slideOpenAnimation.Evaluate(1-animationProgress);
    }

    public override void OnTriggerChange()
    {
        //Blank, unused
    }
}
