using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FunctionProviderPrimitiveAnim : MonoBehaviour
{
    private float frame = 0;
    private bool isAnimating = false;

    public float timePerFrame = 0.5f;

    public Sprite[] sprites;

    public Image target;

    public UnityEvent whenDone;

    // Update is called once per frame
    void Update()
    {
        if (!isAnimating) return;

        target.sprite = sprites[(int)frame];

        frame += Time.deltaTime / timePerFrame;

        if (frame >= sprites.Length)
        {
            if(whenDone != null) whenDone.Invoke();

            Destroy(this);
        }
    }

    public void StartAnimating()
    {
        isAnimating = true;
    }
}
