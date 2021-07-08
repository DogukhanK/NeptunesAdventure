using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public float speed = 0.3f;
    public AudioSource sfx;
    public GameObject score;
    public GameObject score2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);  //rotate relative to the world
    }

    void OnTriggerEnter()
    {
        UpdateScore.currentScore += 1;               //update score value in UpdateScore script
        sfx.Play();                                  //play sfx 
        Destroy(gameObject);                         //remove gem form the world
    }
}
