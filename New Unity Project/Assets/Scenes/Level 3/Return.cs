using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public static int completed = 0;
    public static bool didWin = false;
    public GameObject player;
    public GameObject bridge;
    public GameObject npc;

    void Start()
    {
        if (completed >= 1)
        {
            if (didWin)
            {
                bridge.SetActive(true);
                Destroy(npc);
            }
        }
    }

}
