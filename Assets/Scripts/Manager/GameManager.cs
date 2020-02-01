using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game States
public enum GameState { MAIN_MENU, CONTROLS, GAME, PAUSED }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
	public GameManager() { }
	private static GameManager instance = null;
	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set; }

	public static GameManager Instance
	{
		get
		{
			if (GameManager.instance == null)
			{
				GameManager.instance = new GameManager();
				//DontDestroyOnLoad(GameManager.instance);
			}
			return GameManager.instance;
		}

	}

	public void SetGameState(GameState state)
	{
		this.gameState = state;
		OnStateChange();
	}

	public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

}
