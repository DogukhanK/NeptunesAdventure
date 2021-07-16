using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private Transform camera;

    private float x = 0.0f;
    private float y = 0.0f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    public float camDist = 3.0f;
    public float camHeight = 2.0f;

    private bool isKeyDown = false;

    void Start()
    {
        camera = transform;

        cameraSetup();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isKeyDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isKeyDown = false;
        }
    }

    void LateUpdate()
    {
        if (isKeyDown)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            //

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -camDist) + player.position;

            camera.rotation = rotation;
            camera.position = position;
        }
        else
        {
            camera.position = new Vector3(player.position.x, player.position.y + camHeight, player.position.z - camDist);
            x = 0;
            y = 0;
        }
    }

    public void cameraSetup()
    {
        camera.position = new Vector3(player.position.x, player.position.y + camHeight, player.position.z - camDist);
    }
}
