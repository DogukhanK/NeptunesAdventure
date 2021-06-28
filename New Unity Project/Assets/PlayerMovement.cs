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
    Vector3 direction;

    float speed = 1.0f;
    bool move;
    float range = 1.0f;

    Animator walk;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        nextposition = Vector3.forward;
        currentdirection = up;

        walk = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        walk.SetBool("walk", false);

        if (Input.GetKeyDown(KeyCode.W))
        {
            nextposition = Vector3.forward;
            currentdirection = up;
            walk.SetBool("walk", true);
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            nextposition = Vector3.left;
            currentdirection = left;
            walk.SetBool("walk", true);
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            nextposition = Vector3.back;
            currentdirection = down;
            walk.SetBool("walk", true);
            move = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            nextposition = Vector3.right;
            currentdirection = right;
            walk.SetBool("walk", true);
            move = true;
        }

        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentdirection;
            if (move)
            {
                if (blocked())
                {
                    destination = transform.position + nextposition;
                    direction = nextposition;
                    move = false;
                }
            }
        }
    }

    bool blocked()
    {
        Ray checker = new Ray(transform.position + new Vector3(0, 0.5f, 0), transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(checker, out hit, range))
        {
            if (hit.collider.tag == "Obstacle")
            {
                return false;
            }
        }

        return true;
    }
}
