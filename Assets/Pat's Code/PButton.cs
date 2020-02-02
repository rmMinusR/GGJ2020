using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PButton : MonoBehaviour
{
    public bool button1;
    private Animator buttonAnim;

    void Start()
    {
        buttonAnim = GetComponent<Animator>();
    }
    void Update()
    {
        buttonAnim.SetBool("button1", button1);
    }

    void OnTriggerEnter2D(Collider2D Player) { button1 = true; }
    void OnTriggerExit2D(Collider2D Player) { button1 = false; }
}