using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public GameObject trigger;

    private Text textComponent;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = trigger.GetComponent<TextTrigger>().textToDisplay;
        textComponent.enabled = false;
    }

    void Update()
    {
        if (trigger.GetComponent<TextTrigger>().activated)
        {
            timer += Time.deltaTime;
            Debug.Log("Time Displaying: " + timer);
            if (timer >= trigger.GetComponent<TextTrigger>().duration)
            {
                textComponent.enabled = false;
                timer = 0.0f;
                trigger.GetComponent<TextTrigger>().activated = false;
            }
            else
            {
                Debug.Log("Displaying text: " + trigger.GetComponent<TextTrigger>().textToDisplay);
                textComponent.enabled = true;
            }
        }
    }
}
