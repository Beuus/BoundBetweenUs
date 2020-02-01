using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableRope : MonoBehaviour
{
    public string input;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(input))
        {
            GameObject.Find("RopeManager").GetComponent<CreateRope>().isUnbreakable = true;
        }
        else if (Input.GetButtonUp(input))
        {
            GameObject.Find("RopeManager").GetComponent<CreateRope>().isUnbreakable = false;
        }
    }
}
