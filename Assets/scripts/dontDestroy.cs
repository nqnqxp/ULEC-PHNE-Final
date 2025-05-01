using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroy : MonoBehaviour
{
    public Scene currentScene;
    public string currentSceneName;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        if (currentSceneName == "Scene1" || currentSceneName == "Scene2" || currentSceneName == "Scene3")
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
