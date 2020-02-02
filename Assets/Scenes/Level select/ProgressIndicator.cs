using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIndicator : MonoBehaviour
{
    public SpriteRenderer target;

    public Sprite sprEnabled, sprDisabled;

    public void SetState(bool state)
    {
        target.sprite = state ? sprEnabled : sprDisabled;
    }
}
