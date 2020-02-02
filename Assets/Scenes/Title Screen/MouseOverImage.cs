using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image target;

    public Sprite neutral;
    public Sprite mouseOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        target.sprite = mouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target.sprite = neutral;
    }
}
