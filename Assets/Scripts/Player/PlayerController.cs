using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public string leftKey;
    public string rightKey;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey(leftKey);
        bool right = Input.GetKey(rightKey);
        Vector3 movement = new Vector2(0, 0);

        if (left)
            movement = new Vector2(-1, 0) * speed * Time.deltaTime;
        else if (right)
            movement = new Vector2(1, 0) * speed * Time.deltaTime;

        player.position = transform.position + movement;
    }
}
