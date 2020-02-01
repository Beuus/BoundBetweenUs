using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("DesignScene");
    }

    public void controls()
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}