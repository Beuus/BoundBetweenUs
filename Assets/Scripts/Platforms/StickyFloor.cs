using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFloor : MonoBehaviour
{
    private Vector3 m_EnterScale = Vector3.one;
    public Transform m_globalParent = null; //Por defecto el padre global será la raiz de la escena pero podría ser que no fuera así.
    public Transform m_transformToAttach;
    public Quaternion rotation;

    void Start()
    {
        if (m_transformToAttach == null)
            m_transformToAttach = transform;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();

            Vector2 vectorCollision = player.transform.position - this.transform.position;

            if (vectorCollision.normalized.y > 0)
            {
                other.transform.parent = transform;
            }
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.transform.tag == "Player")
        {
            other.transform.parent = null;
        }

    }

}
