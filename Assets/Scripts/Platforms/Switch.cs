using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool activated;
    public float time = 10;
    public string playerTag1;
    public string playerTag2;

    // Start is called before the first frame update
    void start()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(playerTag1) || collision.gameObject.tag.Equals(playerTag2))
        {
            Debug.Log("Colliding");
            activated = true;
            StartCoroutine(BackToOriginalPosition());
        }
    }


    IEnumerator BackToOriginalPosition()
    {
        yield return new WaitForSeconds(time);
        activated = false;

    }
}
