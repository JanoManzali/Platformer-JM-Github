using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSnapshotSwitch : MonoBehaviour
{
    public AudioMixerSnapshot mySnapshot;
    public float fadeTime = 3.0f;
    public float delayTime = 0.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mySnapshot.TransitionTo(fadeTime);
        }
            
    }

}
