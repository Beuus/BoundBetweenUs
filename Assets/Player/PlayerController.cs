using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //float verticalAxis = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalAxis, 0) * speed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
