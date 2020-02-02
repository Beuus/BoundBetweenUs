using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public bool activated;

    // Start is called before the first frame update
    void start()
    {
        activated = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player1") || collision.gameObject.tag.Equals("Player2"))
        {
            Debug.Log("Colliding with text trigger");
            activated = true;
        }
    }
}
