using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //float verticalAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalAxis, 0, 0) * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }
}
