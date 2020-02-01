using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float cameraFactor;

    private Vector3 offset;
    private float fov;

    // Start is called before the first frame update
    void Start()
    {
        fov = Camera.main.orthographicSize;
        Debug.Log(fov);
        offset = ((transform.position - player1.transform.position) + (transform.position - player2.transform.position)) / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector2.Distance(player1.transform.position, player2.transform.position);
        Camera.main.orthographicSize = fov + distance * cameraFactor;
        transform.position = player1.transform.position + (player2.transform.position - player1.transform.position) / 2 + offset;
    }
}
