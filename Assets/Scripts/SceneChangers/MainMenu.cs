using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // to load scenes from main menu specifically 
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Load Level 1
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0); //Load Level 1
    }
    public void BackToLevel5()
    {
        SceneManager.LoadScene(5); //Load Level 1
    }
    public void QuitGame()
    {
        Debug.Log("Game quits when it's built");
        Application.Quit();

    }
}
