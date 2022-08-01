using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicLoopVerb : MonoBehaviour
{
    public AudioSource layer1Dry;
    public AudioSource layer1Wet;
    private bool startedLoop;

    void FixedUpdate()
    {
        if (!layer1Dry.isPlaying && !startedLoop)
        {
            layer1Wet.Play();
            Debug.Log("Done playing");
            startedLoop = true;
        }
    }
}