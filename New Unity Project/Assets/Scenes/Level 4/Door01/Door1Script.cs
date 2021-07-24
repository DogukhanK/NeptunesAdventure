using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
    void Update()
    {
        if (LeverActivation1.activateDoor == true)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
