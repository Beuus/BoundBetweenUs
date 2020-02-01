using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject trigger;
    public Transform target;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position && trigger.GetComponent<Switch>().activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
