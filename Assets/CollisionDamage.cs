using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "FallingObject"){
            GetComponentInParent<CreateRope>().RopeDamage(other.name);
        }   
    }
}
