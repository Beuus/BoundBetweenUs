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

    public string playerTag1;
    public string playerTag2;


    void Start()
    {
        if (m_transformToAttach == null)
            m_transformToAttach = transform;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == playerTag1 || other.transform.tag == playerTag2)
        {
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();

            Vector2 vectorCollision = player.transform.position - this.transform.position;

            if (vectorCollision.normalized.y > 0)
            {
                other.transform.parent = transform;
                //other.transform.localScale = Vector3.one;
            }
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.transform.tag == playerTag1 || other.transform.tag == playerTag2)
        {
            other.transform.parent = null;
        }

    }

}
