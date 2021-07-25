using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1 : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Death.isDead = true;
    }
}
