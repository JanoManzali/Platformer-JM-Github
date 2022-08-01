using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;



    private bool facingLeft = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    private void Move()
    {
        if (facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                //make sure sprite is facing right location, and if it is not, then face right direction
                if (transform.localScale.x != 2)
                {
                    transform.localScale = new Vector3(2, 2);
                    rb.velocity = new Vector2(-speed, rb.velocity.y);

                }
                   
            }
            else
            {
                facingLeft = false;
            }

        }

        else
        {
            if (transform.position.x < rightCap)
            {
                //make sure sprite is facing right location, and if it is not, then face right direction
                if (transform.localScale.x != -2)
                {
                    transform.localScale = new Vector3(-2, 2);
                    rb.velocity = new Vector2(speed, rb.velocity.y);

                }

            }
            else
            {
                facingLeft = true;
            }
        }
    }

}
