using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerExchange : MonoBehaviour
{

    private bool player1collision = false;
    private bool player2collision = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player1") && !player1collision || collision.gameObject.name.Equals("Player2") && !player2collision)
        {
            var jump = collision.gameObject.GetComponent<Jump>();
            var unbreakableRope = collision.gameObject.GetComponent<UnbreakableRope>();
            if (jump != null)
            {
                Destroy(jump);
                collision.gameObject.AddComponent<UnbreakableRope>();
                if (collision.gameObject.name.Equals("Player1"))
                {
                    collision.gameObject.GetComponent<UnbreakableRope>().input = "RopeUnbreakable1";
                    player1collision = true;
                }
                else
                {
                    collision.gameObject.GetComponent<UnbreakableRope>().input = "RopeUnbreakable2";
                    player2collision = true;
                }
            }
            else if (unbreakableRope != null)
            {
                Destroy(unbreakableRope);
                collision.gameObject.AddComponent<Jump>();
                if (collision.gameObject.name.Equals("Player1"))
                {
                    collision.gameObject.GetComponent<Jump>().input = "Jump1";
                    player1collision = true;
                }
                else
                {
                    collision.gameObject.GetComponent<Jump>().input = "Jump2";
                    player2collision = true;
                }
            }
        }
    }
}
