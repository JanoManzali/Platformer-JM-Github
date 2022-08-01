using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{

    public AudioSource GameOverSFX;
    [SerializeField] private float timer = 0.5f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(WaitSound());
        }
    }

    IEnumerator WaitSound()
    {
  
     GameOverSFX.Play();
     yield return new WaitForSeconds(timer);
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
