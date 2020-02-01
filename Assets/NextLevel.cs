using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private bool player1 = false;
    private bool player2 = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player1"){
            player1 = true;
        }
        else if(collision.transform.tag == "Player2"){
            player2 = true;
        }

        if(player1 && player2){
            FindObjectOfType<GameController>().AddLevel();
            GameObject.Destroy(this);
        }
    }
}
