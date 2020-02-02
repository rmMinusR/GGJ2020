using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDoor : MonoBehaviour
{
    public PButton buttonBoy;

    // Start is called before the first frame update
    void Start()
    {
        // connecting to button script
        GameObject b = GameObject.FindGameObjectWithTag("Button1");
        buttonBoy = b.GetComponent<PButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonBoy.button1) { transform.Translate(0, 0.05f, 0); }
        if (buttonBoy.button1 == false) { transform.position = new Vector3(6.34f, -1.1f, 0); }
    }
}
