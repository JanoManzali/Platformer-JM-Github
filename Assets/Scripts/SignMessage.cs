using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMessage : MonoBehaviour
{

    public GameObject SignText;
    public AudioSource SignSFX;

    private void Start()
    {
        SignText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SignText.SetActive(true);
            SignSFX.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SignText.SetActive(false);
        }
    }
}
