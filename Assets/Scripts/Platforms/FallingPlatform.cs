using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float time;

    private Rigidbody2D platform;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with " + collision);
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    IEnumerator FallAfterDelay()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(time);
        Debug.Log("Falling");
        platform.isKinematic = false;
    }
}
