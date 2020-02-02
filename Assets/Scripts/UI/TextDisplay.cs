using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public GameObject show;

    private Text textComponent;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.enabled = false;
    }

    public void EnableText(string text){
        textComponent.enabled = true;
        textComponent.text = text;
        StartCoroutine("StartText");
        show.SetActive(true);
    }

    IEnumerator StartText(){
        
        yield return new WaitForSeconds(timer);
        textComponent.enabled = false;
        show.SetActive(false);
    } 
}
