﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    //[Range(0, 10)]
    //public float JumpingFall = 2.5f;

    //[Range(0, 10)]
    //public float jumpingup = 2f;

    [Range(0, 5)]
    public float  jumpVelocity;

    bool jumping;
    public string jumpKey;

    private Rigidbody2D rb;

    void Start()
    {
        jumping = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(jumpKey) && !jumping)
        {
            jumping = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            jumping = false;
        }
    }
}