﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Awake()
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

    public void BackMenu()
    {
        //start game scene
        _gameManager.SetGameState(GameState.MAIN_MENU);
        Debug.Log(_gameManager.gameState);
        SceneManager.LoadScene("MainMenu");
    }
}
