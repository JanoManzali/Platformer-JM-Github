using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange1 : MonoBehaviour
{
    public GameObject currentGameObject;
    public AudioSource TrapSFX;
    public float alpha = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        currentGameObject = gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        TrapSFX.Play();
        ChangeAlpha(currentGameObject.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
