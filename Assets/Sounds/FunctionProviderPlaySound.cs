using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FunctionProviderPlaySound : MonoBehaviour
{
    public AudioClip sound;

    // Start is called before the first frame update
    public void DoPlaySound()
    {
        GetComponent<AudioSource>().clip = sound;
        GetComponent<AudioSource>().Play();
    }
}
