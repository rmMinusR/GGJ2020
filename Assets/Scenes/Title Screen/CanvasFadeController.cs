using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeController : MonoBehaviour
{
    [Tooltip("List of canvases which are mutually exclusive")]
    public List<CanvasGroup> targets;

    [Tooltip("The time which it should take to fade")]
    public float crossfadeTime;

    private CanvasGroup fadeFrom, fadeTo;
    private float fadeAmount;
    
    void Start()
    {
        fadeFrom = targets[0];
        fadeTo = targets[0];
        fadeAmount = 1;
    }

    void Update()
    {
        //Set each canvas to disappear and no-interact
        foreach(CanvasGroup c in targets)
        {
            c.alpha = 0;
            c.interactable = false;
            c.blocksRaycasts = false;
        }

        //Try to avoid the double-write?
        fadeFrom.alpha = Mathf.Clamp(1 - fadeAmount, 0, 1);
        fadeTo  .alpha = Mathf.Clamp(    fadeAmount, 0, 1);

        //If fade is complete, allow clicking on the target
        if (fadeAmount >= 1)
        {
            fadeTo.interactable = true;
            fadeTo.blocksRaycasts = true;
        }

        //Increment the transition amount
        fadeAmount = Mathf.Clamp(fadeAmount + Time.deltaTime/crossfadeTime, 0, 1);
    }

    public void TryTriggerFade(CanvasGroup target)
    {
        if (fadeAmount < 1) return;
        if (!targets.Contains(target)) targets.Add(target);

        fadeAmount = 0;
        fadeFrom = fadeTo;
        fadeTo = target;

        return;
    }

    public void TryTriggerFade(int index) { TryTriggerFade(targets[index]); }
}
