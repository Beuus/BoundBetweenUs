using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameManager gm;
    private bool player1;
    private bool player2;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player1"))
        {
            player1 = true;
        }
        else if (collider.gameObject.tag.Equals("Player2"))
        {
            player2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player1"))
        {
            player1 = false;
        }
        else if (collider.gameObject.tag.Equals("Player2"))
        {
            player2 = false;
        }
    }

    void Update()
    {
        if (player1 && player2)
            gm.GameWin();
    }
}
