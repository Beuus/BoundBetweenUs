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
        _gameManager = GameManager.Instance;
        _gameManager.OnStateChange += HandleOnStateChange;
    }
    public void HandleOnStateChange()
    {
        Debug.Log("Change!!");
    }

    public void StartGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.GAME);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("DesignScene");
    }


    public void ControlsGame()
    {
        //start game scene
        _gameManager.SetGameState(GameState.CONTROLS);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("Controls");
    }


    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
