using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public static int completed = 0;
    public static bool didWin = false;
    public GameObject player;
    public GameObject bridge;

    void Start()
    {
        if (completed >= 1)
        {
            player.transform.position = new Vector3(0, 0.29f, 45.41f);
            if (didWin)
            {
                bridge.SetActive(true);
            }
        }
    }

}
