using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public string controllerInput;
    public string keysInput;
    public bool controller;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis;
        if (controller)
            horizontalAxis = Input.GetAxis(controllerInput);
        else
            horizontalAxis = Input.GetAxis(keysInput);
        Vector3 movement = new Vector3(horizontalAxis, 0, 0) * speed * Time.deltaTime;
  
        player.transform.localPosition = transform.localPosition + movement;
    }
}
