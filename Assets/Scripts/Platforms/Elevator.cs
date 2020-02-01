using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject trigger;
    public Transform target1;
    public Transform target2;
    public float speed;

    
    // Update is called once per frame
    void Update()
    {
        if (transform.position != target1.position && trigger.GetComponent<Switch>().activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
        } else if (transform.position != target2.position && !trigger.GetComponent<Switch>().activated)
        {
            Debug.Log("baja");
            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
        }

    }


}
