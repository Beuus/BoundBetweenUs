using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public string textToDisplay;
    public GameObject trigger; 

    private Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = textToDisplay;
        textComponent.enabled = false;
    }

    void Update()
    {
        if (trigger.GetComponent<TextTrigger>().activated)
        {
            Debug.Log("Displaying text: " + textToDisplay);
            textComponent.enabled = true;
        }
    }
}
