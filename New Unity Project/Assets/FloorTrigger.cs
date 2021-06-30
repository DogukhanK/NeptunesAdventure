using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTrigger : MonoBehaviour
{
    public GameObject floor;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            floor.GetComponent<Renderer>().material.color = Color.green;
            SceneManager.LoadScene(0);
        }
    }
}
