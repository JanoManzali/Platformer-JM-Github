using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    //Finite State Machine
    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private float hurtforce = 10f;
    public int Scorenum;
    public TMP_Text ScoreText;

    //Audio
    private AudioSource footsfx;
    public AudioClip footstep1;
    public AudioClip footstep2;
    public AudioClip footstep3;
    public AudioClip footstep4;
    AudioClip[] feet;

    public AudioSource JumpSFX;
    public AudioSource CherrySFX;
    public AudioSource PlayerHurtSFX;
    public AudioSource EnemyDieSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        footsfx = GetComponent<AudioSource>();
        feet = new AudioClip[4];
        feet[0] = footstep1;
        feet[1] = footstep2;
        feet[2] = footstep3;
        feet[3] = footstep4;
        StartCoroutine(Footstep());
    }

    private void Update()
    {
        if (state != State.hurt)
        {
            Movement();
        }

        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumator state
    }

    IEnumerator Footstep()
    {
        //If moving
        if (rb.velocity.magnitude > 0 && coll.IsTouchingLayers(ground))
        {
            if (footsfx != null)
            {
                footsfx.clip = feet[Random.Range(0, 4)];
                if (!footsfx.isPlaying)
                {
                    footsfx.Play();
                }
            }
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Footstep());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            CherrySFX.Play();
            Destroy(collision.gameObject);
            AddScore();
        }
    }

    void AddScore()
    {
        Scorenum++;
        ScoreText.text = Scorenum.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (state == State.falling)
            {
                enemy.JumpedOn();
                EnemyDieSFX.Play();
                Jump();
            }

            else
            {
                state = State.hurt;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //Enemy is to my right therefore I should be damaged and move left
                    rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                    PlayerHurtSFX.Play();
                    
                }

                else
                {
                    //Enemy is to my left therefore I should be damaged and move right
                    rb.velocity = new Vector2(hurtforce, rb.velocity.y);
                    PlayerHurtSFX.Play();

                }
            }
        }

        if (other.gameObject.tag == "Ouch")
            {
            state = State.hurt;
            }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");

        //moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        //moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        //jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
            JumpSFX.Play();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        state = State.jumping;
    }


    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //moving
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    }
}
