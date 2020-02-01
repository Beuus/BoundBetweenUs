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
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis;
        if (controller) 
            horizontalAxis = Input.GetAxis(controllerInput);
      
        else
            horizontalAxis = Input.GetAxis(keysInput);

        if (Input.GetAxis(controllerInput) != 0 || Input.GetAxis(keysInput) != 0)
        {
            anim.SetBool("walking", true);
            if (Input.GetAxis(controllerInput) < 0 || Input.GetAxis(keysInput) < 0)
            {
                transform.localScale = new Vector3 (-1, 1, 1); 

            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else {
            anim.SetBool("walking", false);
        }

        Vector3 movement = new Vector3(horizontalAxis, 0, 0) * speed * Time.deltaTime;
  
        player.transform.localPosition = transform.localPosition + movement;
    }
}
