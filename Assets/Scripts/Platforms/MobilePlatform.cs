using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    private Vector3 start;
    public Transform target;
    public float speed;

    private int dir;


    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == target.position)
        {
            dir = -1;
        }
        else if (transform.position == start)
        {
            dir = 1;
        }
        if (dir == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
        }
        else if (dir == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
