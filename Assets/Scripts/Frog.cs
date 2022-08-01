using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private AudioSource frogjump;
    [SerializeField] private AudioSource frogidle;
    private Collider2D coll;

    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
    }
    
    private void Update()
    {
        //Transition from Jump to Fall
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < .1)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }

        //Transition from Fall to Idle
        if(coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", false);
            frogidle.Play();
        }
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
                }

                //Test to see if Frog is on ground, if so jump
                if (coll.IsTouchingLayers(ground))
                {
                    //Jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                    frogjump.Play();
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
                }

                //Test to see if Frog is on ground, if so jump
                if (coll.IsTouchingLayers(ground))
                {
                    //Jump
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                    frogjump.Play();
                }

            }
            else
            {
                facingLeft = true;
            }
        }
    }

}
