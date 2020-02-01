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
        //TODO 1: Cuando el objeto que caiga sea attachable, atachamos el objeto. Ojo, la scala puede cambiar!!!
        //Attachable atachable = other.GetComponent<Attachable>();

        /* if(transformOld == null)
         {
             transformOld = this.transform;
         }

             Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();

              Vector2 vectorCollision = player.transform.position - this.transform.position;

              if (vectorCollision.normalized.y > 0) {

                  Transform newTransform = player.transform;

                  float newPositionPlayer = player.transform.position.x + (this.transform.position.x - transformOld.position.x);
                  newTransform.position = new Vector2(newPositionPlayer, player.transform.position.y);
                  Debug.Log("YAS");
              }

              transformOld = this.transform;*/
        /*if (other.gameObject.tag.Equals("Player"))
        {

            Vector2 vectorCollision = other.gameObject.GetComponent<Rigidbody2D>().transform.position - this.transform.position;

            if (vectorCollision.normalized.y > 0)
            {
                //TODO 1: Cuando el objeto que caiga sea attachable, atachamos el objeto. Ojo, la scala puede cambiar!!!
                Attachable atachable = other.gameObject.GetComponent<Attachable>();
                if (atachable && atachable.IsAttachable)
                {
                    m_EnterScale = other.gameObject.GetComponent<Rigidbody2D>().transform.localScale;
                    //rotation = other.transform.localRotation;
                    other.gameObject.GetComponent<Rigidbody2D>().transform.parent = m_transformToAttach;
                    atachable.IsAttached = true;
                }
            }
        }*/

        if (other.transform.tag == "Player")
        {
            other.transform.parent = transform;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        //TODO 1: Cuando el objeto que caiga sea attachable, atachamos el objeto. Ojo, la scala puede cambiar!!!
        //Attachable atachable = other.GetComponent<Attachable>();

        /*if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject player = collision.gameObject;
            transformOld = null;
        }*/
        /*if (other.gameObject.tag.Equals("Player"))
        {
            Attachable atachable = other.gameObject.GetComponent<Attachable>();

            if (atachable && atachable.IsAttached)
            {
                other.gameObject.GetComponent<Rigidbody2D>().transform.parent = m_globalParent;
                other.gameObject.GetComponent<Rigidbody2D>().transform.localScale = m_EnterScale;
                atachable.IsAttached = false;
                //other.transform.localRotation = rotation;
            }
        }*/
        if (other.transform.tag == "Player")
        {
            other.transform.parent = null;
        }

    }

}
