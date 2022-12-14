using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFinal : MonoBehaviour
{


    private float lenght;
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    private void Start()
    {
        cam = GameObject.Find("Cinemachine");
        startPos = transform.position.x;
        lenght = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (temp < startPos - lenght)
        {
            startPos -= lenght;
        }
                
    }
}
