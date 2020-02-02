using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePlayerController : MonoBehaviour
{
    public GameObject[] player1Images;
    public GameObject[] player2Images;
    public int player;
    private GameManager _gameManager;

    
    void Start()
    {
        if (_gameManager == null)
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("ERROR. Error al cargar el game manager");
        }

        _gameManager.OnStateChange += HandleOnStateChange;

        player1Images[0].SetActive(false);
        player2Images[1].SetActive(false);
        _gameManager.player1 = PlayerGenre.BOY;
        _gameManager.player2 = PlayerGenre.GIRL;
    }

    public void HandleOnStateChange()
    {
        //Debug.Log("Change!!");
    }

    public void ChangePlayerOne()
    {
        if (_gameManager.player1 == PlayerGenre.GIRL)
        {
            player1Images[0].SetActive(false);
            player1Images[1].SetActive(true);

            _gameManager.player1 = PlayerGenre.BOY;
        }
        else
        {
            player1Images[0].SetActive(true);
            player1Images[1].SetActive(false);

            _gameManager.player1 = PlayerGenre.GIRL;
        }
    } 
    
    public void ChangePlayerTwo()
    {
        if (_gameManager.player2 == PlayerGenre.GIRL)
        {
            player2Images[0].SetActive(false);
            player2Images[1].SetActive(true);

            _gameManager.player2 = PlayerGenre.BOY;
        }
        else
        {
            player2Images[0].SetActive(true);
            player2Images[1].SetActive(false);

            _gameManager.player2 = PlayerGenre.GIRL;
        }
    }

}
