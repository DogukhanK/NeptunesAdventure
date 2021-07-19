using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator anim;

    public GameObject message;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PickupChecker.totalCollected == 4)
        {
            message.SetActive(true);
            anim.SetBool("allCollected", true);
            StartCoroutine(displayMessage());
        }
    }



    IEnumerator displayMessage()
    {
        yield return new WaitForSeconds(4);
        message.SetActive(false);
    }
}
