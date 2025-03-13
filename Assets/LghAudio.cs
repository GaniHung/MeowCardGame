using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LghAudio : MonoBehaviour
{
    public static LghAudio instance { get; set; }
    private AudioSource audioS;
    public float volume;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void AudioPlay()
    {
        audioS.Play();
    }
}
