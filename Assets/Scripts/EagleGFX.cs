using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleGFX : MonoBehaviour
{
    public AIPath aiPath;
    public AudioSource wingSFX;

    void WingStop()
    {
        wingSFX.Play();
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }

        else if (aiPath.desiredVelocity.x >= -0.01f)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
    }

}
