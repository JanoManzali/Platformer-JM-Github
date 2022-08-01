using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public int Scoredoor;
    public AudioSource DoorLocked;
    public AudioSource DoorOpen;

    public GameObject SignText;

    private void Start()
    { 
        SignText.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            Scoredoor = GetComponent<PlayerController>().Scorenum;
            if (Scoredoor >= 12)
            {
               StartCoroutine(opensound());
               
            }

            else
            {
                DoorLocked.Play();
                SignText.SetActive(true);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            SignText.SetActive(false);
        }
    }

    IEnumerator opensound()
    {
        DoorOpen.Play();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneName);
    }

}