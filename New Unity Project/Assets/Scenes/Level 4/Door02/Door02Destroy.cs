using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door02Destroy : MonoBehaviour
{
    public GameObject door02;

    public GameObject smoke;

    void Start()
    {
        door02.GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (UpdateScore.gemsCollected == 11)
        {
            door02.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (other.tag == "Player1")
            {
                if (UpdateScore.gemsCollected==11)
                {
                    Destroy(door02);
                    GameObject effect = (GameObject)Instantiate(smoke, transform.position, Quaternion.identity);
                    Destroy(effect, 3.0f);
                }
            }
        }
    }
}
