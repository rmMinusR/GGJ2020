using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoopingAnim : MonoBehaviour
{
    private float frame = 0;

    public float timePerFrame = 0.5f;

    public Sprite[] sprites;

    public Image target;

    // Update is called once per frame
    void Update()
    {
        target.sprite = sprites[(int)frame];

        frame += Time.deltaTime / timePerFrame;

        if (frame >= sprites.Length)
        {
            frame = 0;
        }
    }
}
