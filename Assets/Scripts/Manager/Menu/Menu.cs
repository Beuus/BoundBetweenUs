using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Awake()
    {   
        if(_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        _gameManager.OnStateChange += HandleOnStateChange;
    }
    public void HandleOnStateChange()
    {
        //Debug.Log("Change!!");
    }

    public void StartGame()
    {
        //Cambiamos el sprite
        Debug.Log("Player 1: " + _gameManager.player1.ToString());
        //Cambiamos el sprite
        Debug.Log("Player 2: " + _gameManager.player2.ToString());

        //start game scene
        _gameManager.SetGameState(GameState.CHAMPIONS);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("PlayerSelectorScene");
    }


    public void ControlsGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.CONTROLS);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("Controls");
    }
    public void CreditsGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.CREDITS);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("Credits");
    }


    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
