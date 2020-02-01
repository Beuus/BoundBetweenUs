using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game States
public enum GameState { MAIN_MENU, CONTROLS, CHAMPIONS, GAME, PAUSED }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
	public GameManager() { }

	public enum PlayerGenre { GIRL, BOY }

	public PlayerGenre player1;
	public PlayerGenre player2;

	public static GameManager _gameManager = null;

	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set; }

	public static GameManager Instance
	{
		get
		{
			if (_gameManager == null)
			{
				_gameManager = new GameManager();
				DontDestroyOnLoad(_gameManager);
			}
			return _gameManager;
		}
	}

	public void SetGameState(GameState state)
	{
		this.gameState = state;
		OnStateChange();
	}

	public void OnApplicationQuit()
	{
		Application.Quit();
	}

	public void GameOver()
	{
		Debug.Log("GameOver");
	}
}
