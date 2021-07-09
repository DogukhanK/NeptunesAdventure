using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject platform;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter()
    {
        player.transform.parent = platform.transform;
    }
    void OnTriggerExit()
    {
        player.transform.parent = null;
    }
}
