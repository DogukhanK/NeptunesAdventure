using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 up = Vector3.zero;
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 right = new Vector3(0, 90, 0);
    Vector3 left = new Vector3(0, -90, 0);

    Vector3 currentdirection = Vector3.zero;

    Vector3 destination;
    Vector3 nextposition;

    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        nextposition = Vector3.forward;
        currentdirection = up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            nextposition = Vector3.forward;
            currentdirection = up;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            nextposition = Vector3.left;
            currentdirection = left;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            nextposition = Vector3.back;
            currentdirection = down;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nextposition = Vector3.right;
            currentdirection = right;
        }

        if (Vector3.Distance(destination, transform.position) <= 0.1f)
        {
            destination = transform.position + nextposition;
        }
    }
}
