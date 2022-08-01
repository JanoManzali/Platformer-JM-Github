using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyonLoad: MonoBehaviour
{

    public static DontDestroyonLoad instance = null;
    [SerializeField] private string sceneName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "InsideHouse")
        {
            // Stops playing music in level 1 scene
            Destroy(gameObject);
        }
    }
}