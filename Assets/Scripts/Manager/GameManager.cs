using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Game States
public enum GameState { MAIN_MENU, CONTROLS, CREDITS, CHAMPIONS, GAME, PAUSED, GAMEOVER }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
	public enum PlayerGenre { GIRL, BOY }

	public PlayerGenre player1;
	public PlayerGenre player2;

	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set; }

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	public void SetGameState(GameState state)
	{
		this.gameState = state;
		OnStateChange();
	}
	public void SetPlayer1(PlayerGenre state)
	{
		this.player1 = state;
		OnStateChange();
	}

	public void SetPlayer2(PlayerGenre state)
	{
		this.player2 = state;
		OnStateChange();
	}

	public void OnApplicationQuit()
	{
		Application.Quit();
	}

	public void GameOver()
	{
		this.SetGameState(GameState.GAME);
		Debug.Log(this.gameState);
		SceneManager.LoadScene("RetryScene");
	}
}
