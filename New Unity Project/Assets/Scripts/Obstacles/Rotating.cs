using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{

    private float speed = 7.0f;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed * 10);
    }

    void OnTriggerEnter()
    {
        Debug.Log("ok");
    }
}
