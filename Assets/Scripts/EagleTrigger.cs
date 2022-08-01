using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleTrigger : MonoBehaviour
{

    public GameObject eagle;
    private AudioSource eaglecall;
    private bool hasPlayed = false;


    void Start()
    {
        eagle.GetComponent<AIDestinationSetter>().enabled = false;
        eaglecall = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            eagle.GetComponent<AIDestinationSetter>().enabled = true;
            if(!hasPlayed)
            {
                eaglecall.Play();
                hasPlayed = true;
            }
            

        }

    }
}
