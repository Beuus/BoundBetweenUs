using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerExchange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding with " + collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Player"))
        {
            var jump = collision.gameObject.GetComponent<Jump>();
            var unbreakableRope = collision.gameObject.GetComponent<UnbreakableRope>();
            if (jump != null)
            {
                Destroy(jump);
                collision.gameObject.AddComponent<UnbreakableRope>();
                if (collision.gameObject.name.Equals("Player1"))
                    collision.gameObject.GetComponent<UnbreakableRope>().input = "RopeUnbreakable1";
                else
                    collision.gameObject.GetComponent<UnbreakableRope>().input = "RopeUnbreakable2";
            }
            else if (unbreakableRope != null)
            {
                Destroy(unbreakableRope);
                collision.gameObject.AddComponent<Jump>();
                if (collision.gameObject.name.Equals("Player1"))
                    collision.gameObject.GetComponent<Jump>().input = "Jump1";
                else
                    collision.gameObject.GetComponent<Jump>().input = "Jump2";
            }
        }
    }
}
