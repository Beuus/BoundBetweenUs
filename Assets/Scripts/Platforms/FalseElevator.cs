using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseElevator : MonoBehaviour
{
    public GameObject trigger;
    public Transform target1;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (transform.position != target1.position && trigger.GetComponent<Switch>().activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
        }
      
    }
}
