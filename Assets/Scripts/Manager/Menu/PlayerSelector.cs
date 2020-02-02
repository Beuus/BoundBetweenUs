using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("ERROR. Error al cargar el game manager");
        }

        _gameManager.OnStateChange += HandleOnStateChange;
    }


    public void HandleOnStateChange()
    {
        //Debug.Log("Change!!");
    }


    public void StartGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.GAME);
        Debug.Log(_gameManager.gameState);

        SceneManager.LoadScene("DesignScene");
    }

    public void BackMenu()
    {
        //start game scene
        _gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(_gameManager.gameState);

        SceneManager.LoadScene("MainMenu");
    }

}
