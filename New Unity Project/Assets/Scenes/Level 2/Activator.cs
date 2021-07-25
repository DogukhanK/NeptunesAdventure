using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    MinigameManager minigame;

    private GameObject player;

    void Start()
    {
        minigame = GameObject.Find("MinigameManager").GetComponent<MinigameManager>();
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter()
    {
        minigame.Activated(this.transform.parent.gameObject);
    }
}
