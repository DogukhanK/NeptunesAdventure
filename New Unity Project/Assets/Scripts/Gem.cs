using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public float speed = 0.3f;
    public AudioSource sfx;
    public GameObject score;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World); //rotate relative to the world
    }

    void OnTriggerEnter()
    {
        sfx.Play();
        Destroy(gameObject);
    }
}
