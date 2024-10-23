using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //Save current level to use in Retry()
    string levelToRetry;

    // Start is called before the first frame update
    void Start()
    {
        levelToRetry = PlayerPrefs.GetString("CurrentLevel");
    }

    public void LoadCustomScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadNextScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Retry()
    {
        Debug.Log(levelToRetry);
        SceneManager.LoadScene(levelToRetry);
    }
}

