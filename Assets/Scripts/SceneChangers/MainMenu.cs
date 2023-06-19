using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //Loads Level 1
    }


    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitGame()
    {
        Debug.Log("Game quits when built");
        Application.Quit();

    }
}
