using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;

    private GameObject player;

    public GameObject endGame;

    void Start()
    {
        player = GameObject.FindWithTag("Player1");
    }

    void OnTriggerEnter()
    {
        endGame.SetActive(true);
        player.transform.position = destination.transform.position;
    }
}
