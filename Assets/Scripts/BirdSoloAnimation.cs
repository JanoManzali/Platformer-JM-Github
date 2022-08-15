using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoloAnimation : MonoBehaviour
{

    private Animator anim;
    private float seconds;
    private enum State {SoloBirdIdle, SoloBirdEating, SoloBirdWalking, SoloBirdFlying}
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        seconds = Random.Range(1f, 8f);
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        state = State.SoloBirdIdle;
        yield return new WaitForSeconds(seconds);
        state = State.SoloBirdEating;
        yield return new WaitForSeconds(seconds);
        StartCoroutine(Move());

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            state = State.SoloBirdFlying;
    }
}
