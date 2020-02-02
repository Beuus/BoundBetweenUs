using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public bool activated;
    public string textToDisplay;
    public float duration;
    public Text t;

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
            t.gameObject.GetComponent<TextDisplay>().EnableText(textToDisplay);
        }
    }
}
