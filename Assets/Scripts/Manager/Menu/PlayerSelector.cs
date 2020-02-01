using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ChangePlayer1()
    {
        if (_gameManager.player1 == GameManager.PlayerGenre.GIRL)
        {
            _gameManager.player1 = GameManager.PlayerGenre.BOY;
        }
        else
        {
            _gameManager.player1 = GameManager.PlayerGenre.GIRL;
        }

        //Cambiamos el sprite
        Debug.Log("Player 1: " + _gameManager.player1.ToString());
    }


    public void ChangePlayer2()
    {
        if (_gameManager.player2 == GameManager.PlayerGenre.GIRL)
        {
            _gameManager.player2 = GameManager.PlayerGenre.BOY;
        }
        else
        {
            _gameManager.player2 = GameManager.PlayerGenre.GIRL;
        }


        //Cambiamos el sprite
        Debug.Log("Player 2: " + _gameManager.player2.ToString());
    }


    public void StartGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.CONTROLS);
        Debug.Log(_gameManager.gameState);

        //SceneManager.LoadScene("Game1");
    }

    public void BackMenu()
    {
        //start game scene
        _gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(_gameManager.gameState);

        SceneManager.LoadScene("MainMenu");
    }

}
