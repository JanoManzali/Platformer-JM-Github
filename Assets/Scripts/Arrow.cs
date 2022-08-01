using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float despawnTime = 5f;
    public float speed = 5;
    private Rigidbody2D body;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

        StartCoroutine(Despawn());
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            body.MovePosition(transform.position + transform.forward * speed);

        }
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       

    }
}
