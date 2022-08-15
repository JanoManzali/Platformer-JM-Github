using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChangeSecret : MonoBehaviour
{
    public GameObject currentGameObject;
    public AudioSource TrapSFX;

    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        TrapSFX.Play();
        Color32 col = GetComponent<Renderer>().material.GetColor("_Color");
        col.a = 100;
        GetComponent<Renderer>().material.SetColor("_Color", col);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        Color32 col = GetComponent<Renderer>().material.GetColor("_Color");
        col.a = 255;
        GetComponent<Renderer>().material.SetColor("_Color", col);
    }

}
