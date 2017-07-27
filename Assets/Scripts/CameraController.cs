using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float speedH = 0.002f;
    public float speedV = 0.002f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        yaw += speedH + Input.GetAxis("Mouse X");
        pitch -= speedV + Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
    void LateUpdate()
    {   
        transform.position = player.transform.position + offset;
    }
}