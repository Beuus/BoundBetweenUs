using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    //public Transform target;
    public List<Transform> targets = new List<Transform>();
    public int _indexStart;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _indexStart = 0;
        this.transform.position = targets[_indexStart].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == targets[_indexStart].position)
        {
            if ( (_indexStart + 1) < targets.Count)
            {
                //Next position
                ++_indexStart;
            }
            else
            {
                _indexStart = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targets[_indexStart].position, speed * Time.deltaTime);
    }
}
