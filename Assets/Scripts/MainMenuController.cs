using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Debug.Log("Next Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
    }
}
