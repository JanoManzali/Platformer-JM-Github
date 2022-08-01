using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
        
    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
