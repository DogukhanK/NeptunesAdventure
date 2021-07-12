using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private Transform camera;
    public float camDist = 3.0f;
    public float camHeight = 2.0f;

    void Start()
    {
        camera = transform;
    }

    void Update()
    {
        camera.position = new Vector3(player.position.x, player.position.y + camHeight, player.position.z - camDist);
    }
}
